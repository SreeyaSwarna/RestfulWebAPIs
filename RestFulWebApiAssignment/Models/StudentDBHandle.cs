using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace RestFulWebApiAssignment.Models

{
    public class StudentDBHandle
    {
        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["StudentConn"].ToString();
            con = new SqlConnection(constring);
        }

        //******** ADD NEW EMPLOYEE *********

        public bool AddStudent(StudentModel emodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("StudentCreate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", emodel.Id);
            cmd.Parameters.AddWithValue("@Name", emodel.Name);
            cmd.Parameters.AddWithValue("@Address", emodel.Address);
            cmd.Parameters.AddWithValue("@City", emodel.City);
            cmd.Parameters.AddWithValue("@Department", emodel.Department);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //******** VIEW EMPLOYEES DETAILS *********

        public List<StudentModel> GetStudent()
        {
            connection();
            List<StudentModel> studentList = new List<StudentModel>();
            SqlCommand cmd = new SqlCommand("GetStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentList.Add(
                    new StudentModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Address = Convert.ToString(dr["Address"]),
                        City = Convert.ToString(dr["City"]),
                        Department = Convert.ToInt32(dr["Department"])
                    });
            }
            return studentList;
        }
    }
}
