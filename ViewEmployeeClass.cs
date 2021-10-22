using System;
using System.Collections.Generic;
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
                if (EmployeeDetails.employees.Count != 0)
                {
                    Console.WriteLine("Viewing Employee Details");
                    Console.WriteLine("************************");
                    for (int index = 0; index < EmployeeDetails.employees.Count; index++)
                    {

                        Console.WriteLine($"EmployeeID:{EmployeeDetails.employees[index].EmployeeId.ToUpper()}\nEmployee Name:{EmployeeDetails.employees[index].EmployeeName.ToUpper()}\nMobile Number:{EmployeeDetails.employees[index].EmployeeMob}\nEmail ID:{EmployeeDetails.employees[index].EmployeeEmail}\nDate of Birth:{EmployeeDetails.employees[index].EmployeeDob.ToShortDateString()}\nDate of Join:{EmployeeDetails.employees[index].EmployeeDoj.ToShortDateString()}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine();
                    throw new NoRecordFoundException();
                }
            }
            catch (NoRecordFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }


        }
    }
}
