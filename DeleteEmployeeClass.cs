using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    class DeleteEmployeeClass
    {
        public void DeleteEmployee(string id, string Name = null)
        {
            int delete = EmployeeDetails.employees.FindIndex(x => x.EmployeeId == id);
            EmployeeDetails.employees.RemoveAt(delete);
            Console.WriteLine("Employee Details has been Deleted SuccessFully");
        }
        public void DeleteEmployee(string name)
        {
            int delete = EmployeeDetails.employees.FindIndex(x => x.EmployeeName == name);
            EmployeeDetails.employees.RemoveAt(delete);
            Console.WriteLine("Employee Details has been Deleted SuccessFully");

        }

    }
}
