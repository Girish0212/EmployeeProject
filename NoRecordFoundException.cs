using System;
using System.Runtime.Serialization;

namespace EmployeeManagement
{
    [Serializable]
    internal class NoRecordFoundException : Exception
    {
        public NoRecordFoundException()
        {
            Console.WriteLine("No Records Found");
        }

        public NoRecordFoundException(string message) : base(message)
        {
        }

        public NoRecordFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}