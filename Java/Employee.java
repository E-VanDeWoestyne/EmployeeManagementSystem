public abstract class Employee {

    protected int id;
    protected String first_name;
    protected String last_name;
    protected String dob;
    protected String position;
    protected Departments department;

    public Employee(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department
    ) {
        this.id = id;
        this.first_name = first_name;
        this.last_name = last_name;
        this.dob = dob;
        this.position = position;
        this.department = department;
    }

    public abstract void getPaid();

    public void getPaid(double bonus) {
    }

    public abstract void reportToManager();
}