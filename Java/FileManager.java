import java.io.BufferedWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.List;

public class FileManager implements Runnable {

    private String file_path;
    private List<Employee> employees;

    public FileManager(String file_path, List<Employee> employees) throws InvalidDataException {
        setFilePath(file_path);
        setEmployees(employees);
    }

    @Override
    public void run() {
        writeFile();
        readFile();
    }

    public void writeFile() {
        try (BufferedWriter writer = Files.newBufferedWriter(Path.of(file_path))) {
            for (Employee employee : employees) {
                writer.write(
                    employee.getId() + "," + employee.getFirstName() + "," + employee.getLastName() + ","
                        + employee.getDepartment() + "," + employee.getPosition()
                );
                writer.newLine();
            }
            System.out.println("Employee data written to " + file_path);
        } catch (IOException exception) {
            System.out.println("Write error: " + exception.getMessage());
        }
    }

    public void readFile() {
        try {
            List<String> lines = Files.readAllLines(Path.of(file_path));
            System.out.println("Reading employee data from " + file_path);
            for (String line : lines) {
                System.out.println(line);
            }
        } catch (IOException exception) {
            System.out.println("Read error: " + exception.getMessage());
        }
    }

    public String getFilePath() {
        return file_path;
    }

    public void setFilePath(String file_path) throws InvalidDataException {
        if (file_path == null || file_path.isBlank()) {
            throw new InvalidDataException("File path is required.");
        }
        this.file_path = file_path;
    }

    public List<Employee> getEmployees() {
        return employees;
    }

    public void setEmployees(List<Employee> employees) {
        if (employees == null) {
            this.employees = new ArrayList<>();
            return;
        }
        this.employees = employees;
    }
}
