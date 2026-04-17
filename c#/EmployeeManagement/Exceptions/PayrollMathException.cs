using System;

namespace EmployeeManagement.Exceptions
{
    public class PayrollMathException : Exception
    {
        public PayrollMathException()
        {
        }

        public PayrollMathException(string message)
            : base(message)
        {
        }

        public PayrollMathException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
