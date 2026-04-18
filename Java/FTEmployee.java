public class FTEmployee extends Employee {

    protected double salary;

    public FTEmployee(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double salary
    ) {
        super(id, first_name, last_name, dob, position, department);
        this.salary = salary;
    }

    @Override
    public void getPaid() {
    }

    @Override
    public void reportToManager() {
    }
}
