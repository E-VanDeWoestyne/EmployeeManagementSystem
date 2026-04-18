public class PTEmployee extends Employee {

    private double rate;
    private int hours;

    public PTEmployee(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double rate,
        int hours
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department);
        setRate(rate);
        setHours(hours);
    }

    @Override
    public void getPaid() {
        try {
            if (rate < 0 || hours < 0) {
                throw new PayrollMathException("Rate and hours must be zero or greater.");
            }
            System.out.println("Part-time pay for " + getFirstName() + " " + getLastName() + ": " + (rate * hours));
        } catch (PayrollMathException exception) {
            System.out.println("Payroll error for employee " + getId() + ": " + exception.getMessage());
        }
    }

    @Override
    public void reportToManager() {
        System.out.println(getFirstName() + " " + getLastName() + " reports to Manager.");
    }

    public double getRate() {
        return rate;
    }

    public void setRate(double rate) throws InvalidDataException {
        if (rate < 0) {
            throw new InvalidDataException("Rate must be zero or greater.");
        }
        this.rate = rate;
    }

    public int getHours() {
        return hours;
    }

    public void setHours(int hours) throws InvalidDataException {
        if (hours < 0) {
            throw new InvalidDataException("Hours must be zero or greater.");
        }
        this.hours = hours;
    }
}
