using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentdataSearchSort
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Read student data from text file
            List<string> studentData = ReadStudentData("D:\\Simplilearn\\Main Projects\\Project 3\\studentData.txt");

            // Sort student data by name
            studentData.Sort();

            while (true)
            {
                // Display menu options
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Display all student data");
                Console.WriteLine("2. Search for a student by name");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                // Get user input
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(" ######The Sorted  Student Data List####");
                        studentData.Sort();
                        // Display all student data
                        DisplayStudentData(studentData);
                        break;

                    case "2":
                        // Search for a student by name
                        Console.Write("Enter student name to search: \n");
                        string searchName = Console.ReadLine();
                        List<string> searchResults = SearchStudentsByName(studentData, searchName);

                        if (searchResults.Count > 0)
                        {
                            DisplayStudentData(searchResults);
                            Console.WriteLine(":) Student Found :)");
                        }
                        else
                        {
                            Console.WriteLine(":( Student not found :(");
                        }
                        break;

                    case "3":
                        // Exit the program
                        Console.WriteLine("Exiting..... Thank You...!");

                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static List<string> ReadStudentData(string fileName)
        {
            List<string> studentData = new List<string>();

            try
            {
                string[] lines = File.ReadAllLines(fileName);
                studentData.AddRange(lines);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return studentData;
        }

        static void DisplayStudentData(List<string> studentData)
        {
            Console.WriteLine("***Student Data***\t");

            foreach (string data in studentData)
            {
                Console.WriteLine(data);
            }

            Console.WriteLine();
        }

        static List<string> SearchStudentsByName(List<string> studentData, string name)
        {
            List<string> searchResults = new List<string>();

            foreach (string data in studentData)
            {
                if (data.ToLower().Contains(name.ToLower()))
                {
                    searchResults.Add(data);
                }
            }

            return searchResults;
        }
    }
}