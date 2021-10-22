using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    public abstract class AddEmployeeServer
    {
        public abstract void AddEmployee();
        //public abstract void ViewEmployee();
        //public abstract void UpdateEmployee();
    }
    class AddEmployeeClass:AddEmployeeServer
    {
        Validate validate = new Validate();
        public override void AddEmployee()
        {
            Console.WriteLine("Getting Employee Details");
            Console.WriteLine("************************");
            bool IsValidId = true;
            bool IsValidName = true;
            bool IsValidEmail = true;
            bool IsValidNum = true;
            bool IsValidDob = true;
            bool IsValidDoj = true;

            //Getting the Employee ID 
            while (IsValidId)
            {
                try
                {
                    Console.WriteLine("Enter the Employee Id");
                    string Id = Console.ReadLine();
                    if (validate.ValidateID(Id) == true)
                    {
                        EmployeeDetails.IdOfEmployee = Id;
                        IsValidId = false;
                    }
                    else
                    {
                        throw new FormatException("Enter the Employee ID as ace or ACE followed by 4 digits");
                    }
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
            //Gettting the Employee Name
            while (IsValidName)
            {
                try
                {
                    Console.WriteLine("Enter the Employee Name");
                    string Name = Console.ReadLine();
                    if (validate.ValidateName(Name) == true)
                    {
                        EmployeeDetails.NameOfEmployee = Name;
                        IsValidName = false;
                    }
                    else
                    {
                        throw new FormatException("Employee Name consist only of alphabets, no special characters or numbers");
                    }
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }

            //Getting Employee Email    
            while (IsValidEmail)
            {
                try
                {
                    Console.WriteLine("Enter the Employee Email Id");
                    string Email = Console.ReadLine();
                    if (validate.ValidateEmail(Email) == true)
                    {
                        EmployeeDetails.MailOfEmployee = Email;
                        IsValidEmail = false;
                    }
                    else
                    {
                        throw new FormatException("Employee Email Id should contain @ and the domain should only in alphabets");
                    }

                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }


            //Getting employee mobile Number
            while (IsValidNum)
            {
                try
                {
                    Console.WriteLine("Enter the Employee Mobile number");
                    string Mob = Console.ReadLine();
                    if (validate.ValidateMobile(Mob) == true)
                    {
                        EmployeeDetails.MobileNumber = Convert.ToInt64(Mob);
                        IsValidNum = false;
                    }
                    else
                    {
                        throw new FormatException("Employee Mobile Number consist only of numbers,no alphabets or special characters are allowed");
                    }
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }


            //Getting Employee DOB
            while (IsValidDob)
            {
                try
                {
                    Console.WriteLine("Enter the Employee Dob in the format of YYYY-MM-DD or DD-MM-YYYY");
                    DateTime Dob = Convert.ToDateTime(Console.ReadLine());
                    if (validate.ValidateDOB(Dob) == true)
                    {
                        EmployeeDetails.DateOfBirth = Dob;
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


            //Getting Employee DOJ
            while (IsValidDoj)
            {
                try
                {
                    Console.WriteLine("Enter the Employee Doj in the format of YYYY-MM-DD or DD-MM-YYYY ");
                    DateTime Doj = Convert.ToDateTime(Console.ReadLine());
                    if (validate.ValidateDOJ(Doj) == true)
                    {
                        EmployeeDetails.DateOfJoin = Doj;
                        IsValidDoj = false;
                    }
                    else
                    {
                        throw new FormatException("DOJ should not be in the future");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            var employeestruct = new EmployeeStruct();
            employeestruct.EmployeeId = EmployeeDetails.IdOfEmployee;
            employeestruct.EmployeeName = EmployeeDetails.NameOfEmployee;
            employeestruct.EmployeeMob = EmployeeDetails.MobileNumber;
            employeestruct.EmployeeDob = EmployeeDetails.DateOfBirth;
            employeestruct.EmployeeDoj = EmployeeDetails.DateOfJoin;
            employeestruct.EmployeeEmail = EmployeeDetails.MailOfEmployee;
            EmployeeDetails.employees.Add(employeestruct);


        }
    }
}
