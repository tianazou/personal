class Program
{
    //declaring path to txt file
    private const string accountsFile = "accounts.txt";
    private const string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

    //main menu
    static void Main(string[] args)
    {
        while (true)
        {
            //main menu options
            Console.WriteLine("LOGIN PAGE");
            Console.WriteLine();
            Console.WriteLine("Please select from one of the menu options.");
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");

            //using switch for user choice in main menu
            Console.Write("Enter your choice: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
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


    // --------------METHODS--------------
    //------------------------------------


    //Login method
    static void Login()
    {
        Console.WriteLine("Login:");

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (CheckCredentials(username, password))
        {
            Console.WriteLine("Your login is successful!");
            
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }
    }


    //Checking credentials (as part of the login process)
    static bool CheckCredentials(string username, string password)
    {
        //debugging to make sure the accounts file is found or not
        if (!File.Exists(accountsFile))
        {
            Console.WriteLine("Accounts file not found.");
            return false;
        }

        //reading all lines in the accounts.txt to determine whether the username or password is valid
        string[] lines = File.ReadAllLines(accountsFile);
        foreach (string line in lines)
        {
            string[] parts = line.Split();
            if (parts.Length == 2 && parts[0].Trim() == username && parts[1].Trim() == password)
            {
                return true;
            }
        }
        return false;
    }


    //Registration
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
            //calling GeneratePassword method if user selects 'y' to question above
            password = GeneratePassword();
        }
        else
        {
            Console.Write("Please enter a password (we recommend 10 characters): ");
            password = Console.ReadLine();
      
        }

        // Save username and password to accounts.txt file
        using (StreamWriter writer = new StreamWriter(accountsFile, true))
        {
            writer.WriteLine($"{username} {password}");
        }

        Console.WriteLine("User registered successfully!");
        Console.WriteLine();
        Console.Write("Your new password is: " + password);
        Console.WriteLine();
        Console.WriteLine("Please take note of your new password");

    }


    //Generate random password
    static string GeneratePassword()
    {
        Console.WriteLine();
        Console.WriteLine("A few options will appear for your generated password");
        Console.WriteLine();

        Console.Write("How many characters do you want your password to be? (Optional: We recommend 10 characters): ");
        int length;


        /* This checks the character length input of the generated password. If the input is less than or equal to 1
         it loops the user back to re-enter the password length again */

        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out length) || length <= 1)
            {
                Console.WriteLine("Invalid input. Password length must be a number greater than 1.");
            }
            else
            {
                break;
            }
        }

        // if a valid password length is entered above, the user is presented with the following options
        while (true)
        {
            // Ask user for inclusion of numbers, symbols, and letters
            Console.Write("Do you want your password to include numbers? (y/n): ");
            bool includeNumbers = Console.ReadLine().ToLower() == "y";

            Console.Write("Do you want your password to include symbols? (y/n): ");
            bool includeSymbols = Console.ReadLine().ToLower() == "y";

            Console.Write("Do you want your password to include letters? (y/n): ");
            bool includeLetters = Console.ReadLine().ToLower() == "y";

            // Check if at least one option is chosen. If true, their random password is generated.
            if (includeNumbers || includeSymbols || includeLetters)
            {
                return GenerateRandomPassword(length, includeNumbers, includeSymbols, includeLetters);
            }

            //else, they are looped back to input their preferences again
            else
            {
                Console.WriteLine("You must choose 'Y' for at least one of the given options.");
            }
        }
    }


    // This covers the random password generation
    static string GenerateRandomPassword(int length, bool includeNumbers = true, bool includeSymbols = true, bool includeLetters = true)
    {
        string chars = "";

        if (includeNumbers)
            chars += "0123456789";

        //calls upon the global symbol variable 
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


    //exit program with a 2 second delay
    static void ExitProgram()
    {
        Console.WriteLine("Exiting program...");
        Thread.Sleep(2000); // Delay for 2 seconds
        Environment.Exit(0);
    }
}