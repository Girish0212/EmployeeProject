using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeeManagement
{
    class DeleteEmployeeClass
    {
        bool IsDeleted;
        public void DeleteEmployee(string id, string Name = null)
        {
            DataTable table = SQL.ShowEmployee();
            foreach (DataRow dataRow in table.Rows)
            {
                bool IsMatch = dataRow[0].ToString() == id.ToUpper();
                if (IsMatch)
                {
                    int RowsAffected = SQL.SqlOperation($"DELETE FROM EMPLOYEE WHERE EMPLOYEEID = '{id}'");
                    Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                    Console.WriteLine("Employee Details has been Deleted SuccessFully");
                    Console.WriteLine();
                    IsDeleted = true;
                }
            }
            if (IsDeleted == false)
            {
                Console.WriteLine("Employee Does Not Exists");
                Console.WriteLine();
            }
        }
        public void DeleteEmployee(string name)
        {
            DataTable table = SQL.ShowEmployee();
            foreach (DataRow dataRow in table.Rows)
            {
                bool IsMatch = dataRow[1].ToString() == name;
                if (IsMatch)
                {
                    int RowsAffected = SQL.SqlOperation($"DELETE FROM EMPLOYEE WHERE EMPLOYEENAME = '{name}'");
                    Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                    Console.WriteLine("Employee Details has been Deleted SuccessFully");
                    Console.WriteLine();
                    IsDeleted = true;
                }              
            }
            if (IsDeleted == false)
            {
                Console.WriteLine("Employee Does Not Exists");
                Console.WriteLine();
            }

        }

    }
}
