using Microsoft.VisualBasic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Timers;
using System.Xml;
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

            #region Exercise 4: Unique Email Validator


            // Use Collection to manage unique email addresses.
            // Create a HashSet<string> with a case -insensitive comparer: new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            HashSet<string> emailsValidator = new HashSet<string>(StringComparer.OrdinalIgnoreCase);


            // Add these emails: "ahmed@test.com", "AHMED@test.com", "sara@test.com", "Sara@Test.Com"
            emailsValidator.Add("ahmed@test.com");
            emailsValidator.Add("AHMED@test.com");
            emailsValidator.Add("sara@test.com");
            emailsValidator.Add("Sara@Test.Com");


            // Print Count — how many are actually stored? Explain why.
            Console.WriteLine(emailsValidator.Count);// 2
            // Because we ignored the difference between capital and lowercase letters,
            // they are considered the same.


            // Create two sets: Set A = { 1, 2, 3, 4, 5 } and Set B = { 4,5,6,7,8}
            HashSet<int> setA = new() { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new() { 4, 5, 6, 7, 8 };

            // Print the result of: UnionWith, IntersectWith, ExceptWith
            //UnionWith
            setA.UnionWith(setB);
            foreach (int i in setA)
                Console.Write(i + " ");
            Console.WriteLine("");


            //IntersectWith    
            setA.IntersectWith(setB);
            foreach (int i in setA)
                Console.Write(i + " ");

            Console.WriteLine();

            //ExceptWith
            setA.ExceptWith(setB);
            foreach (int i in setA)
                Console.Write(i + " ");



            // Use IsSubsetOf to check if { 1,2} is a subset of Set A
            Console.WriteLine($" {setA.IsProperSubsetOf(new int[] { 1, 2 })} ");

            #endregion

            #region Exercise 5: Print Queue Simulator

            // Simulate a printer queue
            // Create a Queue<string> and enqueue 5 documents: "Report.pdf", "Invoice.pdf", "Letter.docx", "Resume.pdf", "Photo.jpg"

            Queue<string> simulatePrinter = [];

            simulatePrinter.Enqueue("Report.pdf");
            simulatePrinter.Enqueue("Invoice.pdf");
            simulatePrinter.Enqueue("Letter.docx");
            simulatePrinter.Enqueue("Resume.pdf");
            simulatePrinter.Enqueue("Photo.jpg");


            // Print the queue contents and Count
            foreach (var printer in simulatePrinter)
                Console.Write(printer + "   ");
            Console.WriteLine("\n" + simulatePrinter.Count);

            // Use Peek to see which document will print next(without removing)
            Console.WriteLine(simulatePrinter.Peek());


            // Process the queue: Dequeue each document and print "Printing: [name]"
            int count = simulatePrinter.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Printing: [{simulatePrinter.Dequeue()}]");
            }
            // Try TryDequeue on the now - empty queue — what happens? it will return false
            Console.WriteLine(simulatePrinter.TryDequeue(out string result));
            Console.WriteLine(result);

            #endregion

            #region Exercise 6: Browser History (Undo)

            // Simulate browser back / forward
            // Create a Stack<string> for browser history
            Stack<string> browserHistory = [];

            // Push 5 URLs: "google.com", "github.com", "stackoverflow.com", "youtube.com", "claude.ai"
            browserHistory.Push("google.com");
            browserHistory.Push("github.com");
            browserHistory.Push("stackoverflow.com");
            browserHistory.Push("youtube.com");
            browserHistory.Push("claude.ai");



            // Use Peek to see the current page(top of stack)
            Console.WriteLine(browserHistory.Peek());

            // Press "back" 3 times using Pop — print each page you leave
            Console.WriteLine(browserHistory.Pop());
            Console.WriteLine(browserHistory.Pop());
            Console.WriteLine(browserHistory.Pop());

            // Print the current page after going back
            Console.WriteLine(browserHistory.Peek());

            // Try TryPop on an empty stack — what happens? it will return false 
            browserHistory.Pop();
            browserHistory.Pop();

            Console.WriteLine(browserHistory.TryPop(out string result));
            Console.WriteLine(result);

            #endregion
        }
    }
}
