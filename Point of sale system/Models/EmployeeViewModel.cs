using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Point_of_sale_system.Models
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string cpassword { get; set; }
        public string image { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string RoleName { get; set; }
        public string FatherName { get; set; }
        public string Bio { get; set; }
        public string country { get; set; }
        public string stateOfCountry { get; set; }
        public string city { get; set; }
        public string Addres { get; set; }
        public string Mobile { get; set; }
        public string CollegeName { get; set; }
        public string DegreeName { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}