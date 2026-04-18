import java.util.ArrayList;
import java.util.List;

public class Manager extends FTEmployee {

    private List<Employee> subordinates;

    public Manager(
        int id,
        String first_name,
        String last_name,
        String dob,
        String position,
        Departments department,
        double salary,
        List<Employee> subordinates
    ) throws InvalidDataException {
        super(id, first_name, last_name, dob, position, department, salary);
        setSubordinates(subordinates);
    }

    @Override
    public void reportToManager() {
        System.out.println("Manager " + getFirstName() + " " + getLastName() + " reports to executive leadership.");
    }

    public List<Employee> getSubordinates() {
        return subordinates;
    }

    public void setSubordinates(List<Employee> subordinates) {
        if (subordinates == null) {
            this.subordinates = new ArrayList<>();
            return;
        }
        this.subordinates = subordinates;
    }
}
