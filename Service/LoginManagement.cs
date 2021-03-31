using MVC_Crud.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace MVC_Crud.Service
{
    public class LoginManagement
    {
        public string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;
        public bool LoginValidation(UserModel user)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("LoginValidation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "Login");
                cmd.Parameters.AddWithValue("@username", user.username.ToString());
                //cmd.ExecuteNonQuery();
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (user.password.Equals(_ds.Tables[0].Rows[0]["password"]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}