public abstract class Employee {

    private int id;
    private String first_name;
    private String last_name;
    private String dob;
    private String position;
    private Departments department;

    public Employee(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department
    ) throws InvalidDataException {
        setId(id);
        setFirstName(first_name);
        setLastName(last_name);
        setDob(dob);
        setPosition(position);
        setDepartment(department);
    }

    public abstract void getPaid();

    public void getPaid(double bonus) {
        try {
            if (bonus < 0) {
                throw new PayrollMathException("Bonus cannot be negative.");
            }
            getPaid();
            System.out.println("Bonus applied: " + bonus);
        } catch (PayrollMathException exception) {
            System.out.println("Payroll error for employee " + id + ": " + exception.getMessage());
        }
    }

    public abstract void reportToManager();

    public int getId() {
        return id;
    }

    public void setId(int id) throws InvalidDataException {
        if (id <= 0) {
            throw new InvalidDataException("Employee id must be greater than zero.");
        }
        this.id = id;
    }

    public String getFirstName() {
        return first_name;
    }

    public void setFirstName(String first_name) throws InvalidDataException {
        if (first_name == null || first_name.isBlank()) {
            throw new InvalidDataException("First name is required.");
        }
        this.first_name = first_name;
    }

    public String getLastName() {
        return last_name;
    }

    public void setLastName(String last_name) throws InvalidDataException {
        if (last_name == null || last_name.isBlank()) {
            throw new InvalidDataException("Last name is required.");
        }
        this.last_name = last_name;
    }

    public String getDob() {
        return dob;
    }

    public void setDob(String dob) throws InvalidDataException {
        if (dob == null || dob.isBlank()) {
            throw new InvalidDataException("Date of birth is required.");
        }
        this.dob = dob;
    }

    public String getPosition() {
        return position;
    }

    public void setPosition(String position) throws InvalidDataException {
        if (position == null || position.isBlank()) {
            throw new InvalidDataException("Position is required.");
        }
        this.position = position;
    }

    public Departments getDepartment() {
        return department;
    }

    public void setDepartment(Departments department) throws InvalidDataException {
        if (department == null) {
            throw new InvalidDataException("Department is required.");
        }
        this.department = department;
    }
}