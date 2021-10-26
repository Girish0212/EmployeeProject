using System;
using System.Data;
using System.Threading;
namespace EmployeeManagement
{
    class MainPage
    {
        public void EmployeeSystem()
        {
            var employeedetails = new EmployeeDetails();
            var addemployee = new AddEmployeeClass();
            var viewemployee = new ViewEmployeeClass();
            var deleteemployee = new DeleteEmployeeClass();
            var updateemployee = new UpdateEmployeeClass();
            var updateparticular = new UpdateParticular();
            Console.WriteLine("Employee Management System");
            Console.WriteLine("");
            AvailableOptions:
            Console.WriteLine(" 1.Add Employee");
            Console.WriteLine(" 2.Update Employee");
            Console.WriteLine(" 3.Delete Employee");
            Console.WriteLine(" 4.View Employee Records");
            Console.WriteLine(" 5.Update Particular Records");
            Console.WriteLine(" 6.QUIT");
            Console.WriteLine("\n Choose any number from the above Options : ");
            int Value = int.Parse(Console.ReadLine());
            switch (Value)
            {
                case 1:
                    addemployee.AddEmployee();
                    goto AvailableOptions;
                case 2:
                    Thread MyThread = new Thread(new ThreadStart(updateemployee.UpdateEmployee));
                    MyThread.Start();
                    MyThread.Join();
                    goto AvailableOptions;
                case 3:
                    Console.WriteLine("Delete Employee Details");
                    Console.WriteLine("");
                    Console.WriteLine("1.Delete Employee Details with Employee ID");
                    Console.WriteLine("2.Delete Employee Details with Employee Name");
                    Console.WriteLine("\n Choose any number from the above Options : ");
                    int Option = int.Parse(Console.ReadLine());
                    switch (Option)
                    {
                        case 1:
                            DataTable table = SQL.ShowEmployee();
                            Console.WriteLine("Existing Employee IDs From database");
                            Console.WriteLine("**********************************");
                            foreach (DataRow dataRow in table.Rows)
                            {
                                Console.WriteLine($"{dataRow[0]}");
                            }
                            Console.WriteLine("Enter the ID You want to delete");
                            string Id = Console.ReadLine();
                            deleteemployee.DeleteEmployee(id: Id);
                            break;
                        case 2:
                            table = SQL.ShowEmployee();
                            Console.WriteLine("Existing Employee Names From database");
                            Console.WriteLine("**********************************");
                            foreach (DataRow dataRow in table.Rows)
                            {
                                Console.WriteLine($"{dataRow[1]}");
                            }
                            Console.WriteLine("Enter the Name You want to delete");
                            string Name = Console.ReadLine();
                            deleteemployee.DeleteEmployee(name: Name);
                            break;
                        default:
                            Console.WriteLine($"Specify only the numeric values which ranges from 1 to 2");
                            break;
                    }
                    goto AvailableOptions;
                case 4:
                    viewemployee.ViewEmployee();
                    goto AvailableOptions;
                case 5:
                    updateparticular.UpdateParticularRecord();
                    goto AvailableOptions;
                case 6:
                    return;

                default:
                    Console.WriteLine($"Specify only the numeric values which ranges from 1 to 5.");
                    goto AvailableOptions;
            }
        }
    }
}