using GYPSEA.Controllers.SessionActionFilter;
using GYPSEA.Mapping;
using GYPSEA.Models;
using GYPSEADLL;
using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace GYPSEA.Controllers
{
    public class UsersController : Controller
    {
        public UsersController()
        {
            string connection = ConfigurationManager.ConnectionStrings["datasource"].ConnectionString;
            _usersDataAccess = new UsersDAO(connection);
        }
        private UsersDAO _usersDataAccess;
        private LoggerP logger = new LoggerP();
        // GET: Users

        public ActionResult ViewUsers()
        {
            List<UsersDO> allUsers = _usersDataAccess.ViewUsers();
            List<UsersPO> mappedUsers = new List<UsersPO>();
            try
            {
                foreach (UsersDO dataObject in allUsers)
                {
                    mappedUsers.Add(UsersMap1.UsersDOtoUsersPO(dataObject));
                }
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
            }
            finally
            { }
            return View(mappedUsers);
        }

        [HttpGet]
        [SessionFilter(1, 2)]
        public ActionResult AddUser()
        {
            return View();
        }
        [SessionFilter(1, 2)]
        [HttpPost]
        public ActionResult AddUser(UsersPO form)
        {
            ActionResult oResponse = null;
            try
            {
                if (ModelState.IsValid)
                {
                    UsersDO dataObject = UsersMap1.UsersPOtoDO(form);
                    _usersDataAccess.AddUser(dataObject);
                    oResponse = RedirectToAction("ViewUsers", "Users");
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
            finally
            { }
            return oResponse;
        }
        [SessionFilter(1)]
        [HttpGet]
        public ActionResult UpdateUser(Int64 UserID)
        {
            UsersDO item = _usersDataAccess.ViewUserByID(UserID);
            UsersPO UserToUpdate = UsersMap1.UsersDOtoUsersPO(item);
            return View(UserToUpdate);
        }
        [SessionFilter(1)]
        [HttpPost]
        public ActionResult UpdateUser(UsersPO form)
        {
            ActionResult oresponse = null;
            try
            {
                if (ModelState.IsValid)
                {
                    UsersDO dataObject = UsersMap1.UsersPOtoDO(form);
                    _usersDataAccess.UpdateUser(dataObject);
                    oresponse = RedirectToAction("ViewUsers", "Users");
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
            finally
            { }
            return oresponse;
        }
        [SessionFilter(1)]
        [HttpGet]
        public ActionResult DeleteUser(Int64 UserID)
        {
            _usersDataAccess.DeleteUser(UserID);
            return RedirectToAction("ViewUsers", "Users");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginPO form)
        {
            ActionResult oreponse = null;
            try
            {
                if (ModelState.IsValid)
                {
                    UsersPO login = UsersMap1.UsersDOtoUsersPO(_usersDataAccess.ViewByUserName(form.UserName));
                    if (login != null && login.Password.Trim() == form.Password.Trim())
                    {
                        Session["UserID"] = login.UserID;
                        Session["UserName"] = login.UserName;
                        Session["Password"] = login.Password;
                        Session["RoleID"] = login.RoleID;
                        Session.Timeout = 10;

                        oreponse = RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        oreponse = View(form);
                    }

                }
                else
                {
                    oreponse = View(form);
                }
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
            }
            finally
            { }
            return oreponse;
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterPO form)
        {
            ActionResult oResponse = null;
            if (ModelState.IsValid)
            {
               if (Session["RoleID"] == null)
                {
                    try
                    {
                        form.RoleID = 4;
                        UsersDO dataObject = RegisterMap.RegisterPOtoUsersDO(form);
                        _usersDataAccess.AddUser(dataObject);
                        oResponse = RedirectToAction("Index", "Home");
                    }
                    catch (Exception ex)
                    {
                        logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                        oResponse = RedirectToAction("Index", "Home");
                    }
                    finally
                    {
                        //Do nothing
                    }
                }
               else
                {
                    oResponse = View(form);
                }
            }
            else
            {
                oResponse = RedirectToAction("Index", "Home");
            }
            
            return oResponse;
        }

    }
}