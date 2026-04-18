public class FTEmployee extends Employee {

    private double salary;

    public FTEmployee(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double salary
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department);
        setSalary(salary);
    }

    @Override
    public void getPaid() {
        try {
            if (salary < 0) {
                throw new PayrollMathException("Salary cannot be negative.");
            }
            System.out.println("Full-time pay for " + getFirstName() + " " + getLastName() + ": " + salary);
        } catch (PayrollMathException exception) {
            System.out.println("Payroll error for employee " + getId() + ": " + exception.getMessage());
        }
    }

    @Override
    public void reportToManager() {
        System.out.println(getFirstName() + " " + getLastName() + " reports to Manager.");
    }

    public double getSalary() {
        return salary;
    }

    public void setSalary(double salary) throws InvalidDataException {
        if (salary < 0) {
            throw new InvalidDataException("Salary must be zero or greater.");
        }
        this.salary = salary;
    }
}
