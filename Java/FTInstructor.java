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
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department, salary);
        setOfficeId(office_id);
    }

    @Override
    public void reportToManager() {
        System.out.println("Instructor " + getFirstName() + " " + getLastName() + " reports to Manager.");
    }

    public String getOfficeId() {
        return office_id;
    }

    public void setOfficeId(String office_id) throws InvalidDataException {
        if (office_id == null || office_id.isBlank()) {
            throw new InvalidDataException("Office id is required.");
        }
        this.office_id = office_id;
    }
}
