using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeeManagement
{
    class UpdateParticular
    {
        bool IsUpdated=false;
        public void UpdateParticularRecord()
        {
            var validate = new Validate();
            int RowsAffected;
            bool IsValidName = true;
            bool IsValidEmail = true;
            bool IsValidNum = true;
            bool IsValidDob = true;
            bool IsValidDoj = true;
            DataTable table = SQL.ShowEmployee();
            Console.WriteLine("Existing Employee ID From database");
            Console.WriteLine("**********************************");
            foreach (DataRow dataRow in table.Rows)
            {              
                Console.WriteLine($"{dataRow[0]}");
            }
            Console.WriteLine("Enter the ID from the above You want to Update");
            string Id = Console.ReadLine();
            foreach (DataRow dataRow in table.Rows)
            {
                bool IsMatch = dataRow[0].ToString() == Id.ToUpper();
                if (IsMatch)
                {
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
                            while (IsValidName)
                            {
                                try
                                {
                                    Console.WriteLine($"Enter the name You want to Update for {Id}");
                                    string Name = Console.ReadLine();
                                    if (validate.ValidateName(Name) == true)
                                    {
                                        RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEENAME = '{Name}' WHERE EMPLOYEEID ='{Id}'");
                                        Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                                        Console.WriteLine();
                                        IsValidName = false;
                                    }
                                    else
                                    {
                                        throw new FormatException("Employee Name Should consist only of alphabets,special characters and numbers are not allowed and it should not contain multiple occurence of same alphabets");
                                    }
                                }
                                catch (Exception exception)
                                {
                                    System.Console.WriteLine(exception.Message);
                                }
                            }
                            break;
                        case 2:
                            while (IsValidEmail)
                            {
                                try
                                {
                                    Console.WriteLine($"Enter the Email You want to Update for {Id}");
                                    string Email = Console.ReadLine();
                                    if (validate.ValidateEmail(Email) == true)
                                    {
                                        if (ExistsCheck.EmailDataExist(Email) == 0)
                                        {
                                            RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEEEMAIL = '{Email}' WHERE EMPLOYEEID ='{Id}'");
                                            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                                            Console.WriteLine();
                                            IsValidEmail = false;
                                        }
                                        else
                                        {
                                            throw new FormatException("Employee Email Already Exists");
                                        }
                                    }
                                    else
                                    {
                                        throw new FormatException("Employee Email Id should contain name or id followed by @ and the domain name should only in alphabets");
                                    }

                                }
                                catch (Exception exception)
                                {
                                    System.Console.WriteLine(exception.Message);
                                }
                            }
                            break;
                        case 3:
                            while (IsValidNum)
                            {
                                try
                                {
                                    Console.WriteLine($"Enter the MobileNumber You want to Update for {Id}");
                                    string Mobile = Console.ReadLine();
                                    if (validate.ValidateMobile(Mobile) == true)
                                    {
                                        if (ExistsCheck.MobileDataExist(Mobile) == 0)
                                        {
                                            RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEEMOBILE = '{Mobile}' WHERE EMPLOYEEID ='{Id}'");
                                            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                                            Console.WriteLine();
                                            IsValidNum = false;
                                        }
                                        else
                                        {
                                            throw new FormatException("Employee Mobile Number Already Exists");
                                        }
                                    }
                                    else
                                    {
                                        throw new FormatException("Employee Mobile Number consist only of numbers of length 10,no alphabets or special characters are allowed");
                                    }
                                }
                                catch (Exception exception)
                                {
                                    System.Console.WriteLine(exception.Message);
                                }
                            }
                            break;
                        case 4:
                            while (IsValidDob)
                            {
                                try
                                {
                                    Console.WriteLine($"Enter the DOB You want to Update for {Id}");
                                    DateTime DOB = Convert.ToDateTime(Console.ReadLine());
                                    if (validate.ValidateDOB(DOB) == true)
                                    {
                                        RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEEDOB = '{DOB}' WHERE EMPLOYEEID ='{Id}'");
                                        Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                                        Console.WriteLine();
                                        IsValidDob = false;
                                    }
                                    else
                                    {
                                        throw new FormatException("Age should be 18 to 60 for valid DOB");
                                    }
                                }
                                catch (Exception exception)
                                {
                                    System.Console.WriteLine(exception.Message);
                                }
                            }
                            break;
                        case 5:
                            while (IsValidDoj)
                            {
                                try
                                {
                                    Console.WriteLine($"Enter the DOJ You want to Update for {Id}");
                                    DateTime DOJ = Convert.ToDateTime(Console.ReadLine());
                                    if (validate.ValidateDOJ(DOJ) == true)
                                    {
                                        RowsAffected = SQL.SqlOperation($"UPDATE EMPLOYEE SET EMPLOYEEDOJ = '{DOJ}' WHERE EMPLOYEEID ='{Id}'");
                                        Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                                        Console.WriteLine();
                                        IsValidDoj = false;
                                    }
                                    else
                                    {
                                        throw new FormatException("DOJ should not be in the future and DOJ should be greater than 18 age when compared to DOB");
                                    }
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine(exception.Message);
                                }
                            }
                            break;
                        default:
                            Console.WriteLine($"Specify only the numeric values which ranges from 1 to 5");
                            Console.WriteLine();
                            break;
                    }
                    IsUpdated = true;
                }  
            }
            if(IsUpdated==false)
            {
                Console.WriteLine("Employee Does Not Exists");
                Console.WriteLine();
            }
            
        }
    }
}
