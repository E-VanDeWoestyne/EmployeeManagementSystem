namespace EmployeeManagement.Models
{
    // Part-time IT employee who is assigned a mentor.
    public class PTInfoTech : PTEmployee
    {
        public string MentorName { get; }

        public PTInfoTech(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department, double rate, int hours, string mentorName)
            : base(id, firstName, lastName, dateOfBirth, position, department, rate, hours)
        {
            MentorName = !string.IsNullOrWhiteSpace(mentorName)
                ? mentorName
                : throw new System.ArgumentException("Mentor name cannot be null or empty.", nameof(mentorName));
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"PT InfoTech {FirstName} {LastName} reports to the manager and is mentored by {MentorName}.");
        }

        public override string ToString()
        {
            return base.ToString() + $", MentorName={MentorName}";
        }
    }
}
