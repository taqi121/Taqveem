using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL
    {
        public static string conn = "Data Source=(local);Initial Catalog=PointOfSale;Integrated Security=True";
        public static bool loginUser(string login, string pwd)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string query = "select * from [PointOfSale].[dbo].[Admin]";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string username = reader.GetString(2);
                    string pwd1 = reader.GetString(3);
                    
                    if (login == username && pwd == pwd1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static List<Admin> GetAdmin()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                List<Admin> admins = new List<Admin>();
                con.Open();
                string query = "select * from [PointOfSale].[dbo].[Admin]";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                }
                return admins;
            }
        }
    }
}
