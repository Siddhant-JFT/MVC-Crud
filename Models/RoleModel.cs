using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Crud.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        [Required]
        [Display (Name="Role Name")]
        public string RoleName { get; set; }
        [Required]
        [Display(Name = "Controller Name")]
        public string Controller { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Required]
        [Display(Name = "Created On")]
        public string CreationDate { get; set; }
        [Display(Name = "Modified On")]
        [Required]
        public string ModificationDate { get; set; }
        [Required]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
    }
}