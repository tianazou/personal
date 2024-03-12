namespace OOProgramming_Part1_FieldsAndProperties
{
    //defining a car
    //car -> windows, doors, wheels, engine etc
    //windows -> colour, shaded
    //door -> colour, material, handles
    //wheels -> colour, material
    //engine -> type

    class Car
    {
        Window window1;
        Window window2;
    }

    class Window
    {
        string colour;
        bool shaded;
    }


    class StudentData //blueprint/definition for student data
    {
        //fields = store data
        //variable to store data for the instance of this object
        //we call this a "field"
        public int studentNumber; 
        public string studentFirstName; //variable/fields
        public string studentLastName; //variable/fields
        public int studentAge; //variable/fields

        //methods = action of the object
        public void Show()
        {
            Console.WriteLine(studentNumber);
            Console.WriteLine(studentFirstName);
            Console.WriteLine(studentLastName);
            Console.WriteLine(studentAge);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Data Application");

            //Add first student
            //student1 <- object/variable 
            //StudentData <- Custom datatype(Class) 
            StudentData student1 = new StudentData(); //creating first student object
            student1.studentNumber = 1;
            student1.studentFirstName = "Jinz";
            student1.studentLastName = "Wu";
            student1.studentAge = 21;

            //Add second student
            StudentData student2 = new StudentData();
            student2.studentNumber = 2;
            student2.studentFirstName = "Sarah";
            student2.studentLastName = "Su";
            student2.studentAge = 18;

            //Print the first student
            student1.Show();
            //Console.WriteLine($"{student1.studentNumber} | " +
            //                  $"{student1.studentFirstName} |" +
            //                  $"{student1.studentLastName} | " +
            //                  $"{student1.studentAge}");

            //Print the Second student
            Console.WriteLine($"{student2.studentNumber} | " +
                              $"{student2.studentFirstName} |" +
                              $"{student2.studentLastName} | " +
                              $"{student2.studentAge}");

            //Remove first student
            //Print the only student left

            #region using parrallel List
            /*
            List<int> studentNumber = new List<int>();
            List<string> studentFirstNames = new List<string>();
            List<string> studentLastNames = new List<string>();
            List<int> studentAges = new List<int>();
            //List<string> studentSubjects = new List<string>();

            Console.WriteLine("Student Data Application");

            //Add first student
            studentNumber.Add(001);
            studentFirstNames.Add("Jinz");
            studentLastNames.Add("Wu");
            studentAges.Add(21);

            //Add second student
            studentNumber.Add(002);
            studentFirstNames.Add("Sarah");
            studentLastNames.Add("Su");
            studentAges.Add(18);

            //Remove first student
            studentNumber.RemoveAt(0);
            studentFirstNames.RemoveAt(0);
            studentLastNames.RemoveAt(0);
            //forgot to remove age

            //Print the only student left.
            Console.WriteLine($"{studentNumber[0]} | {studentFirstNames[0]} |" +
                              $"{studentLastNames[0]} | {studentAges[0]}");
            */
            #endregion
        }
    }


}
