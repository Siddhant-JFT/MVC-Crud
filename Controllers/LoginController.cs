using MVC_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Crud.Service;

namespace MVC_Crud.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            LoginManagement login = new LoginManagement();

            if (login.LoginValidation(user))
            {
                System.Web.HttpContext.Current.Application.Lock();
                System.Web.HttpContext.Current.Application["UserRole"] = user.username.ToString();
                System.Web.HttpContext.Current.Application.UnLock();
                return RedirectToAction("List","Roles");
            }
            else
            {
                return View();
            }

        }
    }
}