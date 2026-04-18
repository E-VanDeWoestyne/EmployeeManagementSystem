public class FTInfoTech extends FTEmployee {

    private String on_call_group;

    public FTInfoTech(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double salary,
        String on_call_group
    ) {
        super(id, first_name, last_name, dob, position, department, salary);
        this.on_call_group = on_call_group;
    }

    @Override
    public void reportToManager() {
    }
}
