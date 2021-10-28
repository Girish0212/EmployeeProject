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
            
            DataTable table = SQL.ShowEmployee();
            if (table.Rows.Count >0) {
                Console.WriteLine("Showing Records From the Database");
                foreach (DataRow dataRow in table.Rows)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine($"EmployeeID :{dataRow[0]}\nNAME :{dataRow[1]}\n" +
                        $"MobileNo :{dataRow[2]}\nEmail :{dataRow[3]}\nDOB :{Convert.ToDateTime(dataRow[4]).ToString("dd/MM/yyyy")}\nDOJ :{Convert.ToDateTime(dataRow[5]).ToString("dd/MM/yyyy")}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Records in the Database");
                Console.WriteLine();
            }

        }
    }
}
