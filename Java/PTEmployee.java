public class PTEmployee extends Employee {

    protected double rate;
    protected int hours;

    public PTEmployee(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double rate,
        int hours
    ) {
        super(id, first_name, last_name, dob, position, department);
        this.rate = rate;
        this.hours = hours;
    }

    @Override
    public void getPaid() {
    }

    @Override
    public void reportToManager() {
    }
}
