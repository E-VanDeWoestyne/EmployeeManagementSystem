public class FTAdmin extends FTEmployee {

    private String access_code;

    public FTAdmin(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double salary,
        String access_code
    ) {
        super(id, first_name, last_name, dob, position, department, salary);
        this.access_code = access_code;
    }

    @Override
    public void reportToManager() {
    }
}
