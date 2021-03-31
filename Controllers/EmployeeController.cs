using MVC_Crud.Models;
using MVC_Crud.Service;
using System.Web.Mvc;
namespace MVC_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeServices _empServices;
        public ActionResult List()
        {
            _empServices = new EmployeeServices();
            var model = _empServices.GetEmployeeList();
            return View(model);
        }
        public ActionResult AddEmployee()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeesModel model)
        {
            _empServices = new EmployeeServices();
            _empServices.InsertEmployee(model);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            _empServices = new EmployeeServices();
            var model = _empServices.GetEditById(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeesModel model)
        {
            _empServices = new EmployeeServices();
            _empServices.UpdadteEmp(model);
            return RedirectToAction("List");
        }
        public ActionResult DeleteEmployee(int Id)
        {
            _empServices = new EmployeeServices();
            _empServices.DeleteEmployee(Id);
            return RedirectToAction("List");
        }
    }
}