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
    public class RoleServices
    {
        public string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;
        public List<RoleModel> GetRoleList()
        {
            IList<RoleModel> getRoleList = new List<RoleModel>();
            _ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RolesAddOrEdit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetRoleList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        RoleModel obj = new RoleModel();
                        obj.RoleId = Convert.ToInt32(_ds.Tables[0].Rows[i]["RoleId"]);
                        obj.RoleName = Convert.ToString(_ds.Tables[0].Rows[i]["RoleName"]);
                        obj.Controller = Convert.ToString(_ds.Tables[0].Rows[i]["Controller"]);
                        obj.CreatedBy = Convert.ToString(_ds.Tables[0].Rows[i]["CreatedBy"]);
                        obj.CreationDate = Convert.ToString(_ds.Tables[0].Rows[i]["CreationDate"]);
                        obj.ModifiedBy = Convert.ToString(_ds.Tables[0].Rows[i]["ModifiedBy"]);
                        obj.ModificationDate = Convert.ToString(_ds.Tables[0].Rows[i]["ModificationDate"]);
                        getRoleList.Add(obj);
                    }
                }
            }
            return (List<RoleModel>)getRoleList;
        }
        public void InsertRole(RoleModel model)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RolesAddOrEdit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddRole");
                cmd.Parameters.AddWithValue("@roleName", model.RoleName);
                cmd.Parameters.AddWithValue("@controller", model.Controller);
                cmd.Parameters.AddWithValue("@createdby", model.CreatedBy);
                cmd.ExecuteNonQuery();
            }
        }
        public RoleModel GetEditById(int RoleId)
        {
            RoleModel model = new RoleModel();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RolesAddOrEdit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetRoleById");
                cmd.Parameters.AddWithValue("@roleId", RoleId);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    model.RoleId = Convert.ToInt32(_ds.Tables[0].Rows[0]["RoleId"]);
                    model.RoleName = Convert.ToString(_ds.Tables[0].Rows[0]["RoleName"]);
                    model.Controller = Convert.ToString(_ds.Tables[0].Rows[0]["Controller"]);
                }
            }
            return model;
        }
        public void UpdadteRole(RoleModel model)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RolesAddOrEdit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "EditRole");
                cmd.Parameters.AddWithValue("roleName", model.RoleName);
                cmd.Parameters.AddWithValue("controller", model.Controller);
                cmd.Parameters.AddWithValue("modifiedby", model.ModifiedBy);
                cmd.Parameters.AddWithValue("roleId", model.RoleId);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteRole(int RoleId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RolesAddOrEdit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteRole");
                cmd.Parameters.AddWithValue("@roleId", RoleId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}