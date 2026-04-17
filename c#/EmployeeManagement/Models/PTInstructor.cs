namespace EmployeeManagement.Models
{
    // Part-time instructor employee with a maximum weekly hour limit.
    public class PTInstructor : PTEmployee
    {
        public int MaxHours { get; }

        public PTInstructor(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department, double rate, int hours, int maxHours)
            : base(id, firstName, lastName, dateOfBirth, position, department, rate, hours)
        {
            if (maxHours < 0)
            {
                throw new System.ArgumentException("Max hours cannot be negative.", nameof(maxHours));
            }

            MaxHours = maxHours;
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"PT Instructor {FirstName} {LastName} reports to the manager with a maximum of {MaxHours} weekly hours.");
        }

        public override string ToString()
        {
            return base.ToString() + $", MaxHours={MaxHours}";
        }
    }
}
