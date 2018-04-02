using GYPSEA.Controllers.SessionActionFilter;
using GYPSEA.Mapping;
using GYPSEA.Models;
using GYPSEADLL;
using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using GYPSEABLL.Models;
using GYPSEABLL;
using System.Web.Mvc;

namespace GYPSEA.Controllers
{
    [SessionFilter(1, 2, 3)]
    public class InvoiceController : Controller
    {
        public InvoiceController()
        {
            //constructors for connection strings
            string connectionString = ConfigurationManager.ConnectionStrings["datasource"].ConnectionString;
            _invoiceDataAccess = new InvoiceDAO(connectionString);
            _boatDataAccess = new BoatDAO(connectionString);
        }
        private InvoiceDAO _invoiceDataAccess;
        private BoatDAO _boatDataAccess;
        private LoggerP logger = new LoggerP();
        // GET: Invoice
        [SessionFilter(1, 2, 3)]
        public ActionResult ViewInvoice()
        {
            //else 
            //Redirect user.

            List<InvoicePO> mappedInvoice = new List<InvoicePO>();
            try
            {
                List<InvoiceDO> allInvoices = new List<InvoiceDO>();
                //if the user is an admin or super
                //View all invoices
                if (Session["RoleID"].Equals(1) || Session["RoleID"].Equals(2))
                {
                    allInvoices = _invoiceDataAccess.ViewInvoices();
                }
                else
                {
                    // client views only there invoices
                    long userId = (long)Session["UserID"];
                    allInvoices = _invoiceDataAccess.ViewInvoiceByUserID(userId);
                }

                foreach (InvoiceDO dataObject in allInvoices)
                {
                    mappedInvoice.Add(InvoiceMap1.InvoiceDOtoInvoicePO(dataObject));
                }

            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
            }
            finally { }
            return View(mappedInvoice);

        }
        [SessionFilter(1, 2)]
        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }
        [SessionFilter(1, 2)]
        [HttpPost]
        public ActionResult AddInvoice(InvoicePO form)
        {
            ActionResult oResponse = null;
            try
            {
                if (ModelState.IsValid)
                {
                    //defines variables for boat .. and double days
                    BoatDO boat = _boatDataAccess.ViewBoatByID(form.BoatID);
                    double days = form.DateReturned.Subtract(form.DateChartered).TotalDays;
                    //if greater than 0
                    if (days > 0)
                    {
                        //amount due = cost x days
                        form.AmountDue = boat.CostperDay * (decimal)days;
                        form.CostperDay = boat.CostperDay;
                        InvoiceDO dataObject = InvoiceMap1.InvoicePOtoDO(form);
                        _invoiceDataAccess.AddInvoice(dataObject);
                        oResponse = RedirectToAction("ViewInvoice", "Invoice");
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Date Returned can not be less than Date Chartered.";
                        //TODO: fill select items 
                        oResponse = View(form);
                    }

                }
                else
                {
                    oResponse = View(form);
                }
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
            }
            finally { }
            return oResponse;
        }
        [SessionFilter(1, 2)]
        [HttpGet]
        public ActionResult UpdateInvoice(Int64 InvoiceID)
        {
            //defines the variables
            InvoiceDO item = _invoiceDataAccess.ViewInvoiceByID(InvoiceID);
            InvoicePO invoiceToUpdate = InvoiceMap1.InvoiceDOtoInvoicePO(item);
            return View(invoiceToUpdate);
        }
        [SessionFilter(1, 2)]
        [HttpPost]
        public ActionResult UpdateInvoice(InvoicePO form)
        {
            ActionResult oresponse = null;
            try
            {
                if (ModelState.IsValid)
                {
                    //if info is valid returns to view invoices
                    InvoiceDO dataObject = InvoiceMap1.InvoicePOtoDO(form);
                    _invoiceDataAccess.UpdateInvoice(dataObject);
                    oresponse = RedirectToAction("ViewInvoice", "Invoice");
                }
                else
                {
                    //if not returns the form
                    oresponse = View(form);
                }
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
            }
            finally { }
            return oresponse;
        }
        [SessionFilter(1)]
        [HttpGet]
        public ActionResult DeleteInvoice(int InvoiceID)
        {
            //deletes invoice by ID then returns to view invoice
            _invoiceDataAccess.DeleteInvoice(InvoiceID);
            return RedirectToAction("ViewInvoice", "Invoice");
        }
        
    }
}