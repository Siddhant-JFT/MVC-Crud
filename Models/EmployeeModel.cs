using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Crud.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        public string EmpAge { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required]
        public string MobileNo { get; set; }
    }

}