using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement
{
    public abstract class UpdateEmployeeServer
    {
        public abstract void UpdateEmployee();
    }
    class UpdateEmployeeClass:UpdateEmployeeServer
    {
        Validate validate = new Validate();
        public override void UpdateEmployee()
        {
            var employeestruct = new EmployeeStruct();
            bool IsValidName = true;
            bool IsValidNum = true;
            bool IsValidEmail = true;
            bool IsValidDob = true;
            bool IsValidDoj = true;
            Console.WriteLine("Enter the Employee ID Where you want to update from the given list ");
            for (int index = 0; index < EmployeeDetails.employees.Count; index++)
            {
                Console.WriteLine(EmployeeDetails.employees[index].EmployeeId);
            }
            Console.WriteLine("Enter the ID");
            string Id = (Console.ReadLine());

            for (int index = 0; index < EmployeeDetails.employees.Count; index++)
            {
                if (EmployeeDetails.employees[index].EmployeeId == Id)
                {
                    Console.WriteLine($"Enter the Updated Details for {Id}");
                    //updating Employee Name
                    while (IsValidName)
                    {
                        try
                        {
                            Console.WriteLine("Enter the Employee Name");
                            string Name = Console.ReadLine();
                            if (validate.ValidateName(Name) == true)
                            {
                                EmployeeDetails.employees[index].EmployeeName = Name;
                                IsValidName = false;
                            }
                            {
                                throw new FormatException("Employee Name consist only of alphabets, no special characters or numbers");
                            }
                        }
                        catch (Exception exception)
                        {
                            System.Console.WriteLine(exception.Message);
                        }
                    }



                    //updating employee Email id 
                    while (IsValidEmail)
                    {
                        try
                        {
                            Console.WriteLine("Enter the Employee Email Id");
                            string Email = Console.ReadLine();
                            if (validate.ValidateEmail(Email) == true)
                            {
                                EmployeeDetails.employees[index].EmployeeEmail = Email;
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


                    //updating employee mobile Number
                    while (IsValidNum)
                    {
                        try
                        {
                            Console.WriteLine("Enter the Employee Mobile number");
                            string Mob = Console.ReadLine();
                            if (validate.ValidateMobile(Mob) == true)
                            {
                                EmployeeDetails.employees[index].EmployeeMob = Convert.ToInt64(Mob);
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


                    //updating Employee DOB
                    while (IsValidDob)
                    {
                        try
                        {
                            Console.WriteLine("Enter the Employee Dob in the format of YYYY-MM-DD or DD-MM-YYYY");
                            DateTime Dob = Convert.ToDateTime(Console.ReadLine());
                            if (validate.ValidateDOB(Dob) == true)
                            {
                                EmployeeDetails.employees[index].EmployeeDob = Dob;
                                IsValidDob = false;
                            }
                            else
                            {
                                throw new FormatException("DOB format should be YYYY-MM-DD or DD-MM-YYYY");
                            }
                        }
                        catch (Exception exception)
                        {
                            System.Console.WriteLine(exception.Message);
                        }
                    }


                    //updating Employee DOJ
                    while (IsValidDoj)
                    {
                        try
                        {
                            Console.WriteLine("Enter the Employee Doj in the format of YYYY-MM-DD or DD-MM-YYYY");
                            DateTime Doj = Convert.ToDateTime(Console.ReadLine());
                            if (validate.ValidateDOJ(Doj) == true)
                            {
                                EmployeeDetails.employees[index].EmployeeDoj = Doj;
                                IsValidDoj = false;
                            }
                            else
                            {
                                throw new FormatException("DOJ format should be YYYY-MM-DD or DD-MM-YYYY");
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    Console.WriteLine("Employee Details Updated Succesfully");
                }
                else
                {
                    Console.WriteLine("Employee ID doesn't Exist");
                }
            }
        }
        }
}
