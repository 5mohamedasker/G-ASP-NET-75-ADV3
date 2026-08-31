using Microsoft.VisualBasic;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advanced_C__Assignment_3
{
    internal class Program
    {
        static void Main()
        {
            #region Exercise 1: Student Grade Manager

            List<int> studentGrade = [85, 92, 78, 95, 88, 70, 100, 65];

            //Print the collection, Count, first and last grade
            Console.WriteLine($"Students Grade Count: {studentGrade.Count}");
            Console.WriteLine($"Students First Grade: {studentGrade.First()}");
            Console.WriteLine($"Students Last Grade: {studentGrade.Last()}\n");


            //Sort the grades ascending, then print
            studentGrade.Sort();
            foreach (var i in studentGrade)
                Console.Write($"{i}  ");



            //Get the first grade above 90
            Console.WriteLine("\n");
            int above90 = studentGrade.Find(x => x > 90);
            Console.WriteLine(above90);


            //Get all grades below 75(failing grades)
            List<int> failingGrades = studentGrade.FindAll(x => x > 75);


            //Remove all failing grades(below 75)
            studentGrade.RemoveAll(x => x < 75);


            //Check if any grade equals 100
            bool gradeEquals100 = studentGrade.Any(x => x == 100);
            Console.WriteLine($"\nGrade Equals 100 : {gradeEquals100}");

            //Create a List<string> where each grade becomes "Grade: X
            List<string> gradestext = [];
            foreach (var i in studentGrade)
            {
                gradestext.Add($"Grade: {i}");
            }
            #endregion

            #region Exercise 2: Leaderboard
            //Create a leaderboard that automatically sorts players by score.
            //Add: 500 = "Ahmed", 200 = "Sara", 800 = "Ali", 350 = "Mona"

            SortedDictionary<int, string> leaderboard = new()
            {
                [500] = "Ahmed",
                [200] = "Sara",
                [800] = "Ali",
                [350] = "Mona"
            };

            //Print all entries(they should be sorted by score automatically)
            foreach (var i in leaderboard)
            {
                Console.WriteLine(i);
            }

            //Access the first key and first value
            Console.WriteLine(leaderboard[500]);

            //Check if score 500 exists
            Console.WriteLine(leaderboard.ContainsKey(500));

            //Safely get the player with score 999
            leaderboard.TryGetValue(999, out string? result);

            //Remove the player with score 200 and print the updated list
            leaderboard.Remove(200);
            foreach (var i in leaderboard)
            {
                Console.WriteLine(i);
            }
            #endregion

            #region Exercise 3: Phone Book

            // Build a phone book application.
            // Create a Collection with 4 contacts(name → phone number)
            Dictionary<string, string> phoneBook = new()
            {
                ["ali"] = "01012345848",
                ["mohamed"] = "0105886587",
                ["asker"] = "01098765e"
            };


            // Add a new contact using [] syntax (add or update)
            phoneBook.Add("noor", "010434893");
            phoneBook["ali"] = "85384658";
            phoneBook["ahmed"] = "01038843";


            // Try adding a duplicate using .Add() — catch the exception and print the error
            try
            {
                phoneBook.Add("ali", "01056844793");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            // Try adding a duplicate using .TryAdd() — print whether it succeeded
            bool result = phoneBook.TryAdd("ali", "018738264873");
            Console.WriteLine(result);


            // Search for a contact that doesn’t exist
            phoneBook.TryGetValue("mona", out string? name);
            Console.WriteLine(name);



            // Get a contact with a fallback of "Not Found"
            Console.WriteLine($"{phoneBook.GetValueOrDefault("tyui") ?? "Not Found"}");


            // Print all Keys on one line, then all Values on another line
            foreach (var key in phoneBook.Keys)
                Console.Write($"{key} ");

            Console.Write("\n");

            foreach (var value in phoneBook.Values)
                Console.Write($"{value} "); 
            #endregion

        }
    }
}
