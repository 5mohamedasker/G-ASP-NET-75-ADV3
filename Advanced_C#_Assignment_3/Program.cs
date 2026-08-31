using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
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

        }
    }
}
