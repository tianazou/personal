using System;
using System.Collections.Generic;
using System.IO;

class Program
{


    static void Main()
    {
        //defining the input and output files (make sure the files are within the sln)
        string inputFile = "characters.txt";
        string outputFile = "character-count.txt";

        //reading input file
        string text = File.ReadAllText(inputFile);


        //Calls the CountABCCharacters method to count the characters from the input file
        Dictionary<char, int> characterCount = CountABCCharacter(text);

        // Calls the WriteCharCountToFile method to write the characters counted to the output file
        WriteCharCountToFile(outputFile, characterCount);

        // Calls the CharCountDisplay to display the characterCount the way we wish
        CharCountDisplay(characterCount);

    }



    //This method, CountABCCharacters takes a string text (from the inputFile) as input and returns a dictionary with the count of each alphabetic character

    static Dictionary<char, int> CountABCCharacter(string text)
    {
        Dictionary<char, int> characterCount = new Dictionary<char, int>();

        //counting the characters
        for (char c = 'A'; c <= 'Z'; c++)
        {
            characterCount.Add(c, 0);
        }

        return characterCount;
    }

    //This method WriteCharCountToFile takes the characterCount and writes it to the outputFile using StreamWriter
    static void WriteCharCountToFile(string outputFile, Dictionary<char, int> characterCount)
        {
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (var entry in characterCount)
                {
                    writer.WriteLine($"{entry.Key} {entry.Value}"); //this displays it as, for example, C 01
                }
            }
        }

    //method for displaying character counts
        static void CharCountDisplay(Dictionary<char, int> characterCount)
        {
            Console.WriteLine("Character Counts:");
            foreach (var entry in characterCount)
            {
                Console.WriteLine($"{entry.Key} {entry.Value}");
            }
        }

    }
   