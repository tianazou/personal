namespace MainMethodArgumentsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("-------input--------");
            //foreach (string argument in args)
            //{
            //    Console.WriteLine(argument);
            //}
            //Console.WriteLine("--------------------");

            Console.WriteLine("Student Data application");

            //Console.WriteLine("Please enter your First Name: ");
            //string firstName = Console.ReadLine();

            //Console.WriteLine("Please enter your Last Name: ");
            //string lastName = Console.ReadLine();

            //Console.WriteLine("Please enter age: ");
            //int age = int.Parse(Console.ReadLine());

            string firstName = args[0];
            string lastName = args[1];

            int age;
            bool sucess = int.TryParse(args[2], out age);

            if (sucess)
            {
                string[] subjects = new string[5];
                subjects[0] = "C# Programming";
                subjects[1] = "Javascript Mobile";
                subjects[2] = "ICT";
                DisplayStudentData(firstName, lastName, age, subjects);
            }
            else
            {
                Console.WriteLine("Error - third argument must be an int for age");
            }
            Console.ReadLine();
            
            //declare a method
            //<return type> <methodName>(Optional parameters)

            void DisplayStudentData(string argFirstName, string argLastName, int argAge, 
                                    string[] argSubjects)
            {
                Console.WriteLine("\n-------------------------");
                Console.WriteLine($"FirstName: {argFirstName} " +
                                  $"| LastName:{argLastName} " +
                                  $"| Age:{argAge}\n");

                Console.WriteLine("My Subjects\n");
                foreach (string subject in argSubjects)
                {
                    Console.WriteLine(subject);
                }
            }

        }
    }
}
