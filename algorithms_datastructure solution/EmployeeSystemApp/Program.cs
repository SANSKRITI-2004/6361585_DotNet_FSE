using System;

public class Employee
{
    public int EmployeeId;
    public string Name;
    public string Position;
    public double Salary;

    public Employee(int id, string name, string position, double salary)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Position: {Position}, Salary: {Salary}");
    }
}

public class EmployeeSystem
{
    private Employee[] employees;
    private int count;

    public EmployeeSystem(int size)
    {
        employees = new Employee[size];
        count = 0;
    }

    public void AddEmployee(Employee emp)
    {
        if (count < employees.Length)
        {
            employees[count++] = emp;
        }
        else
        {
            Console.WriteLine("Employee list is full!");
        }
    }

    public void SearchEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                Console.WriteLine("Employee Found:");
                employees[i].Display();
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }

    public void TraverseEmployees()
    {
        Console.WriteLine("\nAll Employees:");
        for (int i = 0; i < count; i++)
        {
            employees[i].Display();
        }
    }

    public void DeleteEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                // Shift remaining employees left
                for (int j = i; j < count - 1; j++)
                {
                    employees[j] = employees[j + 1];
                }
                employees[count - 1] = null;
                count--;
                Console.WriteLine($"Employee {id} deleted.");
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }
}

public class Program
{
    public static void Main()
    {
        EmployeeSystem system = new EmployeeSystem(5);

        system.AddEmployee(new Employee(1, "Alice", "Manager", 70000));
        system.AddEmployee(new Employee(2, "Bob", "Developer", 60000));
        system.AddEmployee(new Employee(3, "Charlie", "Tester", 50000));

        system.TraverseEmployees();

        system.SearchEmployee(2);

        system.DeleteEmployee(2);

        system.TraverseEmployees();
    }
}
