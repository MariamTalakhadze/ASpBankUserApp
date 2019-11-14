using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using Bussiness.Service;
using System.Web.Security;
using ASpBankUserApp.Bussiness.IServiceInterface;
using System.Net;


namespace ASpBankUserApp.Controllers
{
    public class UserController : Controller
    {

        private UserService userdb = new UserService();
        private GenderService genderdb = new GenderService();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPost( String Name, String Password)
        {
            if(Name.Equals("admin") && Password.Equals("1"))
            {
                return View("index");
            }
            return View("Login");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult RegistrationPost()
        {
            return View();
        }
        public ActionResult OperationRegistration()
        {
            return View();
        }
    }
}