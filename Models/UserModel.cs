using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
namespace MVC_Crud.Models
{
    public class UserModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}