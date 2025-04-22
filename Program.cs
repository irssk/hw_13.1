using System;
using System.Collections.Generic;

class Program
{
    static List<string> todos = new List<string>();
    static List<bool> isCompleted = new List<bool>();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== TO DO LIST ===");
            ShowTodos();
            Console.WriteLine();
            Console.WriteLine("1. Add a case");
            Console.WriteLine("2. Mark the task as completed");
            Console.WriteLine("3. Delete case");
            Console.WriteLine("4. Download to-do list");
            Console.WriteLine("5. Exit");
            Console.Write("Select action (1-5): ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddTodo();
                    break;
                case "2":
                    MarkAsDone();
                    break;
                case "3":
                    DeleteTodo();
                    break;
                case "4":
                    LoadTodos();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Incorrect selection. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddTodo()
    {
        Console.Write("Enter case name: ");
        string task = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(task))
        {
            todos.Add(task);
            isCompleted.Add(false);
            Console.WriteLine("Case added!");
        }
        else
        {
            Console.WriteLine("The case name cannot be empty.");
        }
        Pause();
    }

    static void ShowTodos()
    {
        if (todos.Count == 0)
        {
            Console.WriteLine("The to-do list is empty.");
            return;
        }

        for (int i = 0; i < todos.Count; i++)
        {
            string status = isCompleted[i] ? "[☑]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {todos[i]}");
        }
    }

    static void MarkAsDone()
    {
        if (todos.Count == 0)
        {
            Console.WriteLine("The list is empty. There is nothing to mark.");
            Pause();
            return;
        }

        Console.Write("Enter the case number to mark: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= todos.Count)
        {
            isCompleted[index - 1] = true;
            Console.WriteLine("The task is marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid case number.");
        }
        Pause();
    }

    static void DeleteTodo()
    {
        if (todos.Count == 0)
        {
            Console.WriteLine("The list is empty. There is nothing to delete.");
            Pause();
            return;
        }

        Console.Write("Enter the case number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= todos.Count)
        {
            todos.RemoveAt(index - 1);
            isCompleted.RemoveAt(index - 1);
            Console.WriteLine("The case has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid case number.");
        }
        Pause();
    }

    static void LoadTodos()
    {
        Console.WriteLine("=== LOADED LIST ===");
        if (todos.Count == 0)
        {
            Console.WriteLine("The list is empty.");
        }
        else
        {
            ShowTodos();
        }
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}