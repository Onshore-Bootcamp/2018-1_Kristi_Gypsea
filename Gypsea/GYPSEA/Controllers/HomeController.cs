using GYPSEA.Mapping;
using GYPSEA.Models;
using GYPSEABLL;
using GYPSEABLL.Models;
using GYPSEADLL;
using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GYPSEA.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            //constructor for connection strings
            string connectionString = ConfigurationManager.ConnectionStrings["datasource"].ConnectionString;
            _invoiceDataAccess = new InvoiceDAO(connectionString);
            _boatDataAccess = new BoatDAO(connectionString);
        }
        private BoatDAO _boatDataAccess;
        private InvoiceDAO _invoiceDataAccess;
        private LoggerP logger = new LoggerP();

        //Home Page
        public ActionResult Index()
        {
            ActionResult oResponse = null;
            //Give the list to the view to display
            try
            {
                List<InvoiceDO> allInvoices = _invoiceDataAccess.ViewInvoices();
                List<InvoiceBO> mappedInvoices = new List<InvoiceBO>();
                foreach (InvoiceDO dataObject in allInvoices)
                {
                    mappedInvoices.Add(HighestProfitMap.InvoiceDOtoInvoiceBO(dataObject));
                }
                List<KeyValuePair<BoatPO, int>> topDisplay = new List<KeyValuePair<BoatPO, int>>();
                List<KeyValuePair<Int64, int>> topBoats = InvoiceBLO.TopBoatsByInvoiceCount(mappedInvoices);
                foreach (KeyValuePair<Int64, int> record in topBoats)
                {
                    BoatDO dataObject = _boatDataAccess.ViewBoatByID(record.Key);
                    BoatPO boat = BoatMap1.BoatDOtoBoatPO(dataObject);
                    topDisplay.Add(new KeyValuePair<BoatPO, int>(boat, record.Value));
                }
                oResponse = View(topDisplay);
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
            }
            finally
            {

            }
            return oResponse;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}