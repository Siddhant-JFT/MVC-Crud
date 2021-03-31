using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Crud.Models
{
    public class EmployeesModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Employee Name")]
        public string EmpName { get; set; }
        [Required]
        [Display(Name = "Employee Age")]
        public string EmpAge { get; set; }
        [Required]
        [Display(Name = "Employee Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required]
        [Display(Name = "Employee Phone")]
        public string MobileNo { get; set; }
    }
}