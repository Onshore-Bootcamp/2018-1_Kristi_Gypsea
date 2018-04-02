using GYPSEA.Controllers.SessionActionFilter;
using GYPSEA.Mapping;
using GYPSEA.Models;
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
    [SessionFilter(1, 2, 3, 4)]
    public class BoatController : Controller
    {
        public BoatController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["datasource"].ConnectionString;
            _boatDataAccess = new BoatDAO(connectionString);
        }
        private BoatDAO _boatDataAccess;
        private LoggerP logger = new LoggerP();
        // GET: Boat
        [SessionFilter(1, 2, 3, 4)]
        public ActionResult ViewSailboats()
        {
            List<BoatDO> allSailboats = _boatDataAccess.ViewSailboats();

            List<BoatPO> mappedBoats = new List<BoatPO>();

            try
            {

                foreach (BoatDO dataObject in allSailboats)
                {
                    mappedBoats.Add(BoatMap1.BoatDOtoBoatPO(dataObject));
                }


            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
            }
            finally { }
            
            return View(mappedBoats);
        }
        [SessionFilter(1)]
        [HttpGet]
        public ActionResult AddSailboats()
        {
            return View();
        }
        [SessionFilter(1)]
        [HttpPost]
        public ActionResult AddSailboats(BoatPO form)
        {
            ActionResult oResponse = null;
            try
            {
                if (ModelState.IsValid)
                {
                    BoatDO dataObject = BoatMap1.BoatPOtoDO(form);
                    _boatDataAccess.AddSailboats(dataObject);
                    oResponse = RedirectToAction("ViewSailboats", "Boat");
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
        [SessionFilter(1)]
        [HttpGet]
        public ActionResult UpdateSailboat(Int64 BoatID)
        {
            BoatDO item = _boatDataAccess.ViewBoatByID(BoatID);
            BoatPO boatToUpdate = BoatMap1.BoatDOtoBoatPO(item);
            return View(boatToUpdate);
        }
        [SessionFilter(1)]
        [HttpPost]
        public ActionResult UpdateSailboat(BoatPO form)
        {
            ActionResult oresponse = null;
            try
            {
                if (ModelState.IsValid)
                {
                    BoatDO dataObject = BoatMap1.BoatPOtoDO(form);
                    _boatDataAccess.UpdateSailboats(dataObject);
                    oresponse = RedirectToAction("ViewSailboats", "Boat");
                }
                else
                {
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
        public ActionResult DeleteSailboat(Int64 BoatID)
        {
            _boatDataAccess.DeleteSailboats(BoatID);
            return RedirectToAction("ViewSailboats", "Boat");
        }
    }
}