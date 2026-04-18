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
    ) {
        super(id, first_name, last_name, dob, position, department, salary);
        this.subordinates = subordinates;
    }

    @Override
    public void reportToManager() {
    }
}
