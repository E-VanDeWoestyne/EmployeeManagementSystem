public class PTInstructor extends PTEmployee {

    private int max_hours;

    public PTInstructor(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double rate,
        int hours,
        int max_hours
    ) {
        super(id, first_name, last_name, dob, position, department, rate, hours);
        this.max_hours = max_hours;
    }

    @Override
    public void reportToManager() {
    }
}
