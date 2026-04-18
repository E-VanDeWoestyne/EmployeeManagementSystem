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
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department, rate, hours);
        setMaxHours(max_hours);
    }

    @Override
    public void reportToManager() {
        System.out.println("Part-time instructor " + getFirstName() + " " + getLastName() + " reports to Manager.");
    }

    public int getMaxHours() {
        return max_hours;
    }

    public void setMaxHours(int max_hours) throws InvalidDataException {
        if (max_hours < 0) {
            throw new InvalidDataException("Max hours must be zero or greater.");
        }
        this.max_hours = max_hours;
    }
}
