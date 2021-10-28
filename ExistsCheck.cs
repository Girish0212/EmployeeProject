using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeManagement
{
    class ExistsCheck
    {
        public static int IDDataExist(string EmployeeId)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString;
            int count;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM Employee WHERE EmployeeID='{EmployeeId}'", Connection))
                    {
                        Connection.Open();
                        count = (int)cmd.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return count = 0;
            }
        }
        public static int EmailDataExist(string EmployeeEmail)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString;
            int count;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM Employee WHERE EmployeeEmail='{EmployeeEmail}'", Connection))
                    {
                        Connection.Open();
                        count = (int)cmd.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return count = 0;
            }
        }
        public static int MobileDataExist(string EmployeeMobile)
        {
            string ConnString = ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString;
            int count;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM Employee WHERE EmployeeMobile='{EmployeeMobile}'", Connection))
                    {
                        Connection.Open();
                        count = (int)cmd.ExecuteScalar();
                        return count;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return count = 0;
            }
        }
    }
}
