using System;

namespace EmployeeManagement{
    public class EmployeeStruct
    {
        private string Id, Name,Email;
        private DateTime Dob;
        private long Mob;
        private DateTime Doj;
        public string EmployeeId
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public string EmployeeEmail
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }
        public DateTime EmployeeDob
        {
            get
            {
                return Dob;
            }
            set
            {
                Dob = value;
            }
        }
        public DateTime EmployeeDoj
        {
            get
            {
                return Doj;
            }
            set
            {
                Doj = value;
            }
        }
        public long EmployeeMob
        {
            get
            {
                return Mob;
            }
            set
            {
                Mob = value;
            }
        }
    }
}