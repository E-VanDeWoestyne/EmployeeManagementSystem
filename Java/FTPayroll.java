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
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department, salary);
        setCertificateId(certificate_id);
    }

    @Override
    public void reportToManager() {
        System.out.println("Payroll employee " + getFirstName() + " " + getLastName() + " reports to Manager.");
    }

    public String getCertificateId() {
        return certificate_id;
    }

    public void setCertificateId(String certificate_id) throws InvalidDataException {
        if (certificate_id == null || certificate_id.isBlank()) {
            throw new InvalidDataException("Certificate id is required.");
        }
        this.certificate_id = certificate_id;
    }
}
