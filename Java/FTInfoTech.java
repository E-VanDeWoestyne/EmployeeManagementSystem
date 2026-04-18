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
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department, salary);
        setOnCallGroup(on_call_group);
    }

    @Override
    public void reportToManager() {
        System.out.println("IT employee " + getFirstName() + " " + getLastName() + " reports to Manager.");
    }

    public String getOnCallGroup() {
        return on_call_group;
    }

    public void setOnCallGroup(String on_call_group) throws InvalidDataException {
        if (on_call_group == null || on_call_group.isBlank()) {
            throw new InvalidDataException("On-call group is required.");
        }
        this.on_call_group = on_call_group;
    }
}
