using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeeManagement
{
    class DeleteEmployeeClass
    {
        public void DeleteEmployee(string id, string Name = null)
        {
            //int delete = EmployeeDetails.employees.FindIndex(x => x.EmployeeId == id);
            //EmployeeDetails.employees.RemoveAt(delete);
            int RowsAffected = SQL.SqlOperation($"DELETE FROM EMPLOYEE WHERE EMPLOYEEID = '{id}'");
            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
            Console.WriteLine("Employee Details has been Deleted SuccessFully");
        }
        public void DeleteEmployee(string name)
        {
            //int delete = EmployeeDetails.employees.FindIndex(x => x.EmployeeName == name);
            //EmployeeDetails.employees.RemoveAt(delete);
            int RowsAffected = SQL.SqlOperation($"DELETE FROM EMPLOYEE WHERE EMPLOYEENAME = '{name}'");
            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
            Console.WriteLine("Employee Details has been Deleted SuccessFully");

        }

    }
}
