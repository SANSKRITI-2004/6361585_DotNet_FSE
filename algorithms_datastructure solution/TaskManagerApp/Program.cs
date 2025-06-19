using System;

public class Task
{
    public int TaskId;
    public string TaskName;
    public string Status;

    public Task(int taskId, string taskName, string status)
    {
        TaskId = taskId;
        TaskName = taskName;
        Status = status;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {TaskId}, Name: {TaskName}, Status: {Status}");
    }
}

public class Node
{
    public Task Task;
    public Node Next;

    public Node(Task task)
    {
        Task = task;
        Next = null;
    }
}

public class TaskList
{
    private Node head;

    public TaskList()
    {
        head = null;
    }

    // Add task to the end
    public void AddTask(Task task)
    {
        Node newNode = new Node(task);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }
    }

    // Search by ID
    public void SearchTask(int taskId)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Task.TaskId == taskId)
            {
                Console.WriteLine("Task Found:");
                current.Task.Display();
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Task not found.");
    }

    // Delete by ID
    public void DeleteTask(int taskId)
    {
        if (head == null)
        {
            Console.WriteLine("Task list is empty.");
            return;
        }

        if (head.Task.TaskId == taskId)
        {
            head = head.Next;
            Console.WriteLine("Task deleted.");
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Task.TaskId == taskId)
            {
                current.Next = current.Next.Next;
                Console.WriteLine("Task deleted.");
                return;
            }
            current = current.Next;
        }

        Console.WriteLine("Task not found.");
    }

    // Traverse and display all tasks
    public void DisplayAllTasks()
    {
        Node current = head;
        Console.WriteLine("\nAll Tasks:");
        while (current != null)
        {
            current.Task.Display();
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        TaskList taskList = new TaskList();

        taskList.AddTask(new Task(1, "Design DB Schema", "Pending"));
        taskList.AddTask(new Task(2, "Write API", "In Progress"));
        taskList.AddTask(new Task(3, "Test API", "Pending"));

        taskList.DisplayAllTasks();

        taskList.SearchTask(2);

        taskList.DeleteTask(1);

        taskList.DisplayAllTasks();
    }
}
