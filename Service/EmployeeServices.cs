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
    public class EmployeeServices
    {
        public string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;
        public List<EmployeesModel> GetEmployeeList()
        {
            IList<EmployeesModel> getEmpList = new List<EmployeesModel>();
            _ds = new DataSet();
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmpList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                if(_ds.Tables.Count > 0)
                {
                    for (int i = 0; i<_ds.Tables[0].Rows.Count; i++)
                    {
                        EmployeesModel obj = new EmployeesModel();
                        obj.Id = Convert.ToInt32(_ds.Tables[0].Rows[i]["Id"]);
                        obj.EmpName = Convert.ToString(_ds.Tables[0].Rows[i]["EmpName"]);
                        obj.EmpAge = Convert.ToString(_ds.Tables[0].Rows[i]["EmpAge"]);
                        obj.EmailId = Convert.ToString(_ds.Tables[0].Rows[i]["EmailId"]);
                        obj.MobileNo = Convert.ToString(_ds.Tables[0].Rows[i]["MobileNo"]);
                        getEmpList.Add(obj);
                    }
                }
            }
            return (List<EmployeesModel>)getEmpList;  
        }
        public void InsertEmployee(EmployeesModel model)
        {
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddEmployee");
                cmd.Parameters.AddWithValue("@EmpName", model.EmpName );
                cmd.Parameters.AddWithValue("@EmpAge", model.EmpAge);
                cmd.Parameters.AddWithValue("@EmpEmailId", model.EmailId);
                cmd.Parameters.AddWithValue("@EmpMobileNo", model.MobileNo);
                cmd.ExecuteNonQuery();
            }
        }
        public EmployeesModel GetEditById(int Id)
        {
            EmployeesModel model = new EmployeesModel();
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmployeeById");
                cmd.Parameters.AddWithValue("@EmpId", Id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if(_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToInt32(_ds.Tables[0].Rows[0]["Id"]);
                    model.EmpName = Convert.ToString(_ds.Tables[0].Rows[0]["EmpName"]);
                    model.EmpAge= Convert.ToString(_ds.Tables[0].Rows[0]["EmpAge"]);
                    model.EmailId = Convert.ToString(_ds.Tables[0].Rows[0]["EmailId"]);
                    model.MobileNo = Convert.ToString(_ds.Tables[0].Rows[0]["MobileNo"]);
                }
            }
            return model;
        }
        public void UpdadteEmp(EmployeesModel model)
        {
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateEmployee");
                cmd.Parameters.AddWithValue("EmpName",model.EmpName);
                cmd.Parameters.AddWithValue("EmpAge", model.EmpAge);
                cmd.Parameters.AddWithValue("EmpEmailId", model.EmailId);
                cmd.Parameters.AddWithValue("EmpMobileNo", model.MobileNo);
                cmd.Parameters.AddWithValue("EmpId", model.Id);
                cmd.ExecuteNonQuery();
            }      
        }
        public void DeleteEmployee(int Id)
        {
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeViewOrInsert",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteEmployee");
                cmd.Parameters.AddWithValue("@EmpId", Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}