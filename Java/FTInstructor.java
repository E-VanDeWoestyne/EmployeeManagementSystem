public class FTInstructor extends FTEmployee {

    private String office_id;

    public FTInstructor(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double salary,
        String office_id
    ) {
        super(id, first_name, last_name, dob, position, department, salary);
        this.office_id = office_id;
    }

    @Override
    public void reportToManager() {
    }
}
