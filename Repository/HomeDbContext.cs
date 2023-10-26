using System.Data.SqlClient;
using System.Data;


namespace CollegeGrievanceCell.Models
{
    public class HomeDbContextClass
    {
        public readonly string connectionString;

        public HomeDbContextClass(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public List<StudentLogin> GetCredentials()
        {
            List<StudentLogin> list = new List<StudentLogin>();

            SqlConnection con = new SqlConnection(connectionString);
            string query = "GetCredentials";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                StudentLogin studentLogin = new StudentLogin();
                studentLogin.UserName = reader["UserName"].ToString();
                studentLogin.Password = reader["Password"].ToString();
                studentLogin.Designation = reader["Designation"].ToString();
                list.Add(studentLogin);
            }
            con.Close();
            return list;
        }

        public bool InsertData(StudentLogin obj)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            string query = "INSERTDETAILS";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@UserName", obj.UserName);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@Department", obj.Department);
            cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber==null);
            cmd.Parameters.AddWithValue("@EmailId", obj.EmailId==null);
            cmd.Parameters.AddWithValue("@Designation", obj.Designation);

            con.Open();
            int k = cmd.ExecuteNonQuery();
            con.Close();
            if (k != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteStudent(int id)
        {
            SqlConnection con=new SqlConnection(_connectionString);
            string query = "DeleteStudent";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId",id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }



    }
}





