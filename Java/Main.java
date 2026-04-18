import java.io.File;
import java.util.ArrayList;
import java.util.List;

public class Main {

    // Entry point for the EmployeeManagement prototype application.
    // This method demonstrates object creation, polymorphism, exception handling,
    // manager reporting, file persistence, and simple thread-based parallelism.
    public static void main(String[] args) {
        String filePath = System.getProperty("user.dir") + File.separator + "employees.txt";
        FileManager fileManager;
        List<Employee> employees = new ArrayList<>();

        try {
            fileManager = new FileManager(filePath, new ArrayList<>());

            // Create a set of sample employees for the prototype.
            employees.add(new FTInstructor(
                    1, "Janet", "Morris", "1982-11-04",
                    "Instructor", Departments.Staff, 92000, "B12"));

            employees.add(new FTPayroll(
                    2, "Rafael", "Martinez", "1979-06-19",
                    "Payroll Specialist", Departments.Payroll, 78000, "PAY-4432"));

            employees.add(new PTInstructor(
                    3, "Ava", "Chen", "1996-02-17",
                    "Adjunct Instructor", Departments.Staff, 42.50, 18, 20));

            employees.add(new PTInfoTech(
                    4, "Daniel", "Owens", "1992-09-05",
                    "IT Support", Departments.IT, 36.00, 22, "Priya"));
        } catch (InvalidDataException ex) {
            // Handle invalid employee data provided during object creation.
            System.out.println("Invalid employee data: " + ex.getMessage());
            return;
        } catch (Exception ex) {
            // Catch any other unexpected errors and stop the program.
            System.out.println("Unexpected error while creating employees: " + ex.getMessage());
            return;
        }

        // Demonstrate dynamic binding: each employee invokes their own implementation.
        for (Employee employee : employees) {
            employee.reportToManager();
            employee.getPaid();
        }

        // Demonstrate overloaded method call for static binding with bonuses.
        employees.get(0).getPaid(500);
        employees.get(2).getPaid(150);

        // This call triggers internal PayrollMathException handling because the bonus
        // is negative.
        employees.get(3).getPaid(-25);

        // Add demo employees to the file manager for persistence.
        fileManager.getEmployees().addAll(employees);

        Manager manager;
        try {
            manager = new Manager(
                    100, "Admin", "Manager", "1975-01-01",
                    "Department Manager", Departments.Admin, 120000, null);
        } catch (InvalidDataException ex) {
            System.out.println("Error creating manager: " + ex.getMessage());
            return;
        }

        manager.getSubordinates().add(employees.get(0));
        manager.getSubordinates().add(employees.get(2));
        manager.getSubordinates().add(employees.get(3));

        manager.reportToManager();

        // Run file I/O in a separate thread to demonstrate parallel execution.
        Thread fileThread = new Thread(fileManager);
        fileThread.setDaemon(true);
        fileThread.setName("FileManagerThread");

        fileThread.start();

        System.out.println("\nMain thread continues while file operations execute in a separate thread.");
        displayEmployeeSummary(employees);

        // Wait for the file manager thread to complete before exiting.
        try {
            fileThread.join();
        } catch (InterruptedException ex) {
            System.out.println("Thread interrupted: " + ex.getMessage());
        }
        System.out.println("File operations completed.");
    }

    private static void displayEmployeeSummary(List<Employee> employees) {
        System.out.println("\nEmployee summary:");
        for (Employee employee : employees) {
            System.out.println("[" + employee.getClass().getSimpleName() + "] Id=" + employee.getId()
                    + ", Name=" + employee.getFirstName() + " " + employee.getLastName()
                    + ", DOB=" + employee.getDob()
                    + ", Position=" + employee.getPosition()
                    + ", Department=" + employee.getDepartment());
        }
        System.out.println();
    }
}
