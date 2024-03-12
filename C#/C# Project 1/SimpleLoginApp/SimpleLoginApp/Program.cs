using System;
using System.IO;
using System.Threading;

class Program
{
    private const string accountsFile = "accounts.txt";
    private const int defaultPasswordLength = 10;
    private const string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("LOGIN PAGE");
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    ExitProgram();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.");
                    break;
            }
        }
    }

    static void Login()
    {
        Console.WriteLine("Login:");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (CheckCredentials(username, password))
        {
            Console.WriteLine("Login successful!");
            // Additional functionality can be added here, such as accessing user's data.
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
    }

    static bool CheckCredentials(string username, string password)
    {
        string[] lines = File.ReadAllLines(accountsFile);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2 && parts[0] == username && parts[1] == password)
            {
                return true;
            }
        }
        return false;
    }

    static void Register()
    {
        Console.WriteLine("Register:");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Would you like us to help you generate a password? (Y/N): ");
        string generatePasswordYesNo = Console.ReadLine().ToLower();

        string password;
        if (generatePasswordYesNo == "y")
        {
            password = GeneratePassword();
        }
        else
        {
            Console.Write("Enter password (must be 10 characters): ");
            password = Console.ReadLine();
      
        }

        // Save username and password to accounts file
        using (StreamWriter writer = new StreamWriter(accountsFile, true))
        {
            writer.WriteLine($"{username},{password}");
        }

        Console.WriteLine("User registered successfully!");
    }

    static string GeneratePassword()
    {
        Console.WriteLine("Options for Generated Password:");

        Console.Write("How many characters do you want your password to be? (We recommend 10 characters): ");
        int length;

        if (!int.TryParse(Console.ReadLine(), out length) || length <= 4)
        {
            length = defaultPasswordLength;
        }

        Console.Write("Do you want your password to include numbers? (y/n): ");
        bool includeNumbers = Console.ReadLine().ToLower() == "y";

        Console.Write("Do you want your password to include symbols? (y/n): ");
        bool includeSymbols = Console.ReadLine().ToLower() == "y";

        Console.Write("Do you want your password to include letters? (y/n): ");
        bool includeLetters = Console.ReadLine().ToLower() == "y";

        return GenerateRandomPassword(length, includeNumbers, includeSymbols, includeLetters);
    }

    static string GenerateRandomPassword(int length, bool includeNumbers = true, bool includeSymbols = true, bool includeLetters = true)
    {
        string chars = "";

        if (includeNumbers)
            chars += "0123456789";
        if (includeSymbols)
            chars += symbols;
        if (includeLetters)
            chars += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        Random random = new Random();
        char[] password = new char[length];

        for (int i = 0; i < length; i++)
        {
            password[i] = chars[random.Next(chars.Length)];
        }

        return new string(password);
    }

    static void ExitProgram()
    {
        Console.WriteLine("Exiting program...");
        Thread.Sleep(2000); // Delay for 2 seconds
        Environment.Exit(0);
    }
}