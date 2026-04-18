public class FTPayroll extends FTEmployee {

    private String certificate_id;

    public FTPayroll(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double salary,
        String certificate_id
    ) {
        super(id, first_name, last_name, dob, position, department, salary);
        this.certificate_id = certificate_id;
    }

    @Override
    public void reportToManager() {
    }
}
