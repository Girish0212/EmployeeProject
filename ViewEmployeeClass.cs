using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeeManagement
{
    public abstract class ViewEmployeeServer
    {
        public abstract void ViewEmployee();
    }
    class ViewEmployeeClass: ViewEmployeeServer
    {
        public override void ViewEmployee()
        {
            try
            {
                DataTable table = SQL.ShowEmployee();
                Console.WriteLine("Showing Records From the Database");
                foreach (DataRow dataRow in table.Rows)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine($"EmployeeID :{dataRow[0]}\nNAME :{dataRow[1]}\n" +
                        $"MobileNo :{dataRow[2]}\nEmail :{dataRow[3]}\nDOB :{dataRow[4]}\nDOJ :{dataRow[5]}");
                }
                
            }
            catch (NoRecordFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }


        }
    }
}
