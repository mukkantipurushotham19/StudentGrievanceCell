using CollegeGrievanceCell.Models;
using System.Data.SqlClient;

namespace CollegeGrievanceCell.Repository
{
    public class ComplaintFormDbContext
    {
        private readonly string _connectionString;
        public ComplaintFormDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool InsertRecord(ComplaintForm obj)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            string query = "RegisterComplaint";
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ComplaintType",obj.ComplaintType);
            cmd.Parameters.AddWithValue("@Description",obj.Description);
            cmd.Parameters.AddWithValue("@DateOfComplaint",obj.DateOfComplaint=DateTime.Now);
            cmd.Parameters.AddWithValue("@Status",obj.Status="null");
            cmd.Parameters.AddWithValue("@UpdateStatus",obj.UpdateStatus="null");
            con.Open();
            int k=cmd.ExecuteNonQuery();
            con.Close();
            if(k > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ComplaintForm GetComplaint(int id)
        {
            ComplaintForm obj=new ComplaintForm();
            obj.ComplaintId = id;
            SqlConnection con =new SqlConnection(_connectionString);
            string query = "GetComplaint";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ComplaintId", obj.ComplaintId);
            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();

            if(dr.HasRows && dr.Read())
            {
                obj.ComplaintId = Convert.ToInt32(dr["ComplaintId"]);
                obj.ComplaintType = dr["ComplaintType"].ToString();
                obj.Description = dr["Description"].ToString();
                obj.DateOfComplaint = (DateTime?)dr["DateOfComplaint"];
                obj.Status = dr["Status"].ToString();
                obj.UpdateStatus = dr["UpdateStatus"].ToString();
            }
            con.Close();
            return obj;
        }
        public List<ComplaintForm> GetPendingComplaints()
        {
            List<ComplaintForm> list=new List<ComplaintForm> ();
            ComplaintForm obj7 = new ComplaintForm();
            SqlConnection con= new SqlConnection(_connectionString);
            string query = "GetPendingComplaints";
            SqlCommand cmd=new SqlCommand(query,con);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UpdateStatus",obj7.UpdateStatus="null");
            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                ComplaintForm obj = new ComplaintForm();
                obj.ComplaintId = Convert.ToInt32(dr["ComplaintId"]);
                obj.ComplaintType = dr["ComplaintType"].ToString();
                obj.Description = dr["Description"].ToString();
                obj.DateOfComplaint = (DateTime?)dr["DateOfComplaint"];
                obj.Status = dr["Status"].ToString();
                obj.UpdateStatus = dr["UpdateStatus"].ToString();

                if (obj.UpdateStatus == "null")
                {
                    list.Add(obj);
                }
            }
            return list;
        }
        public List<ComplaintForm> GetSolveComplaints()
        {
            List<ComplaintForm> list = new List<ComplaintForm>();
            SqlConnection con = new SqlConnection(_connectionString);
            string query = "SolvedComplaints";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.HasRows && dr.Read())
            {
                ComplaintForm obj = new ComplaintForm();
                obj.ComplaintId = Convert.ToInt32(dr["ComplaintId"]);
                obj.ComplaintType = dr["ComplaintType"].ToString();
                obj.Description = dr["Description"].ToString();
                obj.DateOfComplaint = (DateTime?)dr["DateOfComplaint"];
                obj.Status = dr["Status"].ToString();
                obj.UpdateStatus = dr["UpdateStatus"].ToString();

                list.Add(obj);              
            }
            return list;
        }
        public List<ComplaintForm> GetAllComplaints()
        {
            List<ComplaintForm> list = new List<ComplaintForm>();
            SqlConnection con = new SqlConnection(_connectionString);
            string query = "GetAllComplaints";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ComplaintForm obj = new ComplaintForm();
                obj.ComplaintId = Convert.ToInt32(dr["ComplaintId"]);
                obj.ComplaintType = dr["ComplaintType"].ToString();
                obj.Description = dr["Description"].ToString();
                obj.DateOfComplaint = (DateTime?)dr["DateOfComplaint"];
                obj.Status = dr["Status"].ToString();
                obj.UpdateStatus = dr["UpdateStatus"].ToString();
                list.Add(obj);
            }
            con.Close();

            return list;
        }
        public ComplaintForm UpdateStatus(ComplaintForm form)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            string query = "UpdateStatus";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ComplaintId", form.ComplaintId);
            cmd.Parameters.AddWithValue("@Status", form.Status);
            cmd.Parameters.AddWithValue("@UpdateStatus", form.UpdateStatus);

            con.Open();
            int k = cmd.ExecuteNonQuery();
            con.Close();

            return form;
        }






    }
}
