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
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department, rate, hours);
        setMentorName(mentor_name);
    }

    @Override
    public void reportToManager() {
        System.out.println("Part-time IT employee " + getFirstName() + " " + getLastName() + " reports to Manager.");
    }

    public String getMentorName() {
        return mentor_name;
    }

    public void setMentorName(String mentor_name) throws InvalidDataException {
        if (mentor_name == null || mentor_name.isBlank()) {
            throw new InvalidDataException("Mentor name is required.");
        }
        this.mentor_name = mentor_name;
    }
}
