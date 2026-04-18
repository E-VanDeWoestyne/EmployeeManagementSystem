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
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department, salary);
        setAccessCode(access_code);
    }

    @Override
    public void reportToManager() {
        System.out.println("Admin employee " + getFirstName() + " " + getLastName() + " reports to Manager.");
    }

    public String getAccessCode() {
        return access_code;
    }

    public void setAccessCode(String access_code) throws InvalidDataException {
        if (access_code == null || access_code.isBlank()) {
            throw new InvalidDataException("Access code is required.");
        }
        this.access_code = access_code;
    }
}
