public class PTInfoTech extends PTEmployee {

    private String mentor_name;

    public PTInfoTech(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double rate,
        int hours,
        String mentor_name
    ) {
        super(id, first_name, last_name, dob, position, department, rate, hours);
        this.mentor_name = mentor_name;
    }

    @Override
    public void reportToManager() {
    }
}
