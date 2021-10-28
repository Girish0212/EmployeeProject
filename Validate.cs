using System;
using System.Text.RegularExpressions;
using System.Data;
namespace EmployeeManagement
{
    class Validate
    {
        
        public bool ValidateID(string Id)
        {
            bool IsValidId = false;
            if (Regex.IsMatch(Id, "[a][c][e][0-9]{4}") && Id.Length == 7 )
            {
                IsValidId = true;

            }

            return IsValidId;
        }
        public bool ValidateName(string Name)
        {
            bool IsValidName = false;
            if (Regex.IsMatch(Name, "^[a-zA-Z\\s]*$") && IsValidNameOccurrence(Name))
            {
                IsValidName = true;
            }
            return IsValidName;
        }
        public bool ValidateEmail(string Email)
        {
            bool IsValidEmail = false;
            if (Regex.IsMatch(Email, @"[0-9a-zA-Z]@[a-zA-Z]+.[a-zA-Z]{2,}$"))
            {
                IsValidEmail = true;
            }
            return IsValidEmail;
        }
        public bool ValidateMobile(string Mob)
        {
            bool IsValidMob = false;
            if (Regex.IsMatch(Mob, "[6-9][0-9]{9}") && Mob.Length == 10)
            {
                IsValidMob = true;
            }
            return IsValidMob;
        }

        public bool ValidateDOB(DateTime DOB)
        {
            bool IsValidDOB = false;
            if (DateTime.UtcNow.Year - DOB.Year > 18 && DateTime.UtcNow.Year - DOB.Year < 60)
            {
                IsValidDOB = true;
            }

            return IsValidDOB;
        }

        public bool ValidateDOJ(DateTime DOJ)
        {
            bool IsValidDOJ = false;
            if (DOJ.Year - EmployeeDetails.DateOfBirth.Year > 18 && DateTime.UtcNow.Date >= DOJ.Date)
            {
                IsValidDOJ = true;
            }

            return IsValidDOJ;
        }
        static bool IsValidNameOccurrence(string Name)
        {
            bool Result = true;
            for (int Index = 0; Index < Name.Length - 2; Index++)
            {
                if (Name[Index] == Name[Index + 1] && Name[Index] == Name[Index + 2])
                {
                    Result = false;
                    break;
                }

            }
            return Result;
        }
    }
}