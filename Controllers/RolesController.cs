using MVC_Crud.Models;
using MVC_Crud.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Crud.Controllers
{
    public class RolesController : Controller
    {

        private RoleServices _roleServices;



        public ActionResult List()
        {
            _roleServices = new RoleServices();
            var model = _roleServices.GetRoleList();
            return View(model);
        }

        public ActionResult AddRole()
        {

            return View();
        }

        [HttpPost]

        public ActionResult AddRole(RoleModel model)
        {
            _roleServices = new RoleServices();
            _roleServices.InsertRole(model);

            return RedirectToAction("List");

        }
        [HttpGet]
        public ActionResult EditRole(int Id)
        {
            _roleServices = new RoleServices();
            var model = _roleServices.GetEditById(Id);


            return View(model);
        }
        [HttpPost]
        public ActionResult EditRole(RoleModel model)
        {
            _roleServices = new RoleServices();
            _roleServices.UpdadteRole(model);

            return RedirectToAction("List");
        }

        public ActionResult DeleteRole(int RoleId)
        {
            _roleServices = new RoleServices();
            _roleServices.DeleteRole(RoleId);

            return RedirectToAction("List");

        }

    }
}