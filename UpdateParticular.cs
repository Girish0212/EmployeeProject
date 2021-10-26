using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeeManagement
{
    class UpdateParticular
    {
        public void UpdateParticularRecord()
        {
            var validate = new Validate();
            int RowsAffected;           
            DataTable table = SQL.ShowEmployee();
            Console.WriteLine("Existing Employee ID From database");
            Console.WriteLine("**********************************");
            foreach (DataRow dataRow in table.Rows)
            {              
                Console.WriteLine($"{dataRow[0]}");
            }
            Console.WriteLine("Enter the ID from the above You want to Update");
            string Id = Console.ReadLine();
            //int DoExists = SQL.SqlOperation($"SELECT * FROM EMPLOYEE WHERE EXISTS(SELECT * FROM EMPLOYEE WHERE EMPLOYEEID={Id}");
            //if (DoExists >= 1)
            //{
                Console.WriteLine($" 1.Update Name for {Id}");
                Console.WriteLine($" 2.Update Email for {Id}");
                Console.WriteLine($" 3.Update MobileNumber for {Id}");
                Console.WriteLine($" 4.Update DOB for {Id}");
                Console.WriteLine($" 5.Update DOJ for {Id}");
                Console.WriteLine("\n Choose any number from the above Options : ");
                int Value = int.Parse(Console.ReadLine());
                switch (Value)
                {
                    case 1:
                        Console.WriteLine($"Enter the name You want to Update for {Id}");
                        string Name = Console.ReadLine();
                        if (validate.ValidateName(Name))
                        {
                            RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEENAME = '{Name}' WHERE EMPLOYEEID ='{Id}'");
                            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Enter the Email You want to Update for {Id}");
                        string Email = Console.ReadLine();
                        if (validate.ValidateEmail(Email))
                        {
                            RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEEEMAIL = '{Email}' WHERE EMPLOYEEID ='{Id}'");
                            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"Enter the MobileNumber You want to Update for {Id}");
                        string Mobile = Console.ReadLine();
                        if (validate.ValidateMobile(Mobile))
                        {
                            RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEEMOBILE = '{Mobile}' WHERE EMPLOYEEID ='{Id}'");
                            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                        }
                        break;
                    case 4:
                        Console.WriteLine($"Enter the DOB You want to Update for {Id}");
                        DateTime DOB = Convert.ToDateTime(Console.ReadLine());
                        if (validate.ValidateDOB(DOB))
                        {
                            RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEEDOB = '{DOB}' WHERE EMPLOYEEID ='{Id}'");
                            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                        }
                        break;
                    case 5:
                        Console.WriteLine($"Enter the DOJ You want to Update for {Id}");
                        DateTime DOJ = Convert.ToDateTime(Console.ReadLine());
                        if (validate.ValidateDOJ(DOJ))
                        {
                            RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEEDOJ = '{DOJ}' WHERE EMPLOYEEID ='{Id}'");
                            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                        }
                        break;
                    default:
                        Console.WriteLine($"Specify only the numeric values which ranges from 1 to 5");
                        break;
                }
            //}
            //else
            //{
            //    Console.WriteLine("Employee Does Not Exists");
            //}
        }
    }
}
