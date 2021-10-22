using System;
using System.Collections.Generic;
namespace EmployeeManagement
{
    public class EmployeeDetails 
    {
        
        public static string IdOfEmployee, NameOfEmployee, MailOfEmployee;
        public static DateTime DateOfBirth, DateOfJoin;
        public static long MobileNumber;
        public static List<EmployeeStruct> employees = new List<EmployeeStruct>();
    }
}