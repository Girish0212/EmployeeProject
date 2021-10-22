using System;
using System.Collections.Generic;
namespace EmployeeManagement
{

    public abstract class EmployeeServer
    {
        public abstract void AddEmployee();
        public abstract void ViewEmployee();
        public abstract void UpdateEmployee();
    }
    public class EmployeeDetails : EmployeeServer
    {
        Validate validate = new Validate();
        public string IdOfEmployee, NameOfEmployee, MailOfEmployee;
        public static DateTime DateOfBirth, DateOfJoin;
        long MobileNumber;
        List<EmployeeStruct> employees = new List<EmployeeStruct>();

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
                        IdOfEmployee = Id;
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
                        NameOfEmployee = Name;
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
                        MailOfEmployee = Email;
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
                        MobileNumber = Convert.ToInt64(Mob);
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
                        DateOfBirth = Dob;
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
                        DateOfJoin = Doj;
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
            employeestruct.EmployeeId = IdOfEmployee;
            employeestruct.EmployeeName = NameOfEmployee;
            employeestruct.EmployeeMob = MobileNumber;
            employeestruct.EmployeeDob = DateOfBirth;
            employeestruct.EmployeeDoj = DateOfJoin;
            employeestruct.EmployeeEmail = MailOfEmployee;
            employees.Add(employeestruct);


        }
        public override void ViewEmployee()
        {
            try
            {
                if (employees.Count != 0)
                {
                    Console.WriteLine("Viewing Employee Details");
                    Console.WriteLine("************************");
                    for (int index = 0; index < employees.Count; index++)
                    {

                        Console.WriteLine($"EmployeeID:{employees[index].EmployeeId.ToUpper()}\nEmployee Name:{employees[index].EmployeeName.ToUpper()}\nMobile Number:{employees[index].EmployeeMob}\nEmail ID:{employees[index].EmployeeEmail}\nDate of Birth:{employees[index].EmployeeDob.ToShortDateString()}\nDate of Join:{employees[index].EmployeeDoj.ToShortDateString()}");
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
        //polymorphism
        public void DeleteEmployee(string id, string Name = null)
        {
            int delete = employees.FindIndex(x => x.EmployeeId == id);
            employees.RemoveAt(delete);
            Console.WriteLine("Employee Details has been Deleted SuccessFully");
        }
        public void DeleteEmployee(string name)
        {
            int delete = employees.FindIndex(x => x.EmployeeName == name);
            employees.RemoveAt(delete);
            Console.WriteLine("Employee Details has been Deleted SuccessFully");

        }

        public override void UpdateEmployee()
        {
            var employeestruct = new EmployeeStruct();
            bool IsValidName = true;
            bool IsValidNum = true;
            bool IsValidEmail = true;
            bool IsValidDob = true;
            bool IsValidDoj = true;
            Console.WriteLine("Enter the Employee ID Where you want to update from the given list ");
            for (int index = 0; index < employees.Count; index++)
            {
                Console.WriteLine(employees[index].EmployeeId);
            }
            Console.WriteLine("Enter the ID");
            string Id = (Console.ReadLine());
            
            for (int index = 0; index < employees.Count; index++)
            {
                if (employees[index].EmployeeId == Id)
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
                                employees[index].EmployeeName = Name;
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
                                employees[index].EmployeeEmail = Email;
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
                                employees[index].EmployeeMob = Convert.ToInt64(Mob);
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
                                employees[index].EmployeeDob = Dob;
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
                    //while (IsValidDoj)
                    //{
                    //    try
                    //    {
                    //        Console.WriteLine("Enter the Employee Doj in the format of YYYY-MM-DD or DD-MM-YYYY");
                    //        DateTime Doj = Convert.ToDateTime(Console.ReadLine());
                    //        if (validate.ValidateDOJ(Doj) == true)
                    //        {
                    //            employees[index].EmployeeDoj = Doj;
                    //            IsValidDoj = false;
                    //        }
                    //        else
                    //        {
                    //            throw new FormatException("DOJ format should be YYYY-MM-DD or DD-MM-YYYY");
                    //        }
                    //    }
                    //    catch (Exception exception)
                    //    {
                    //        Console.WriteLine(exception.Message);
                    //    }
                    //}
                    Console.WriteLine("Employee Details Updated Succesfully");
                }
                else{
                    Console.WriteLine("Employee ID doesn't Exist");
                }
            }




        }


    }

}