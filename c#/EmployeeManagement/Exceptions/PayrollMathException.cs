using System;

namespace EmployeeManagement.Exceptions
{
    // Custom exception used when payroll math calculations are invalid, such as negative bonuses.
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
