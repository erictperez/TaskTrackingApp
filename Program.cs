using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace TaskTrackingApp
{


    class Program
    {
        static String filename = (@"C:\Users\bulld\Desktop\MSSA Program Files\TaskTrackingApp.txt");


        static void Main(string[] args)
        {
            int menuItem = -1;
            while (menuItem != 0)
            {

                
                menuItem = menu();
                switch (menuItem)
                {
                    case 1:
                        showList();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 2:
                        addItem();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 3:
                        removeItem();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 0:
                        break;

                    default:
                        Console.WriteLine("Don't recognize input.");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Clear();

                        break;
                }
            }
        }


        static void addItem()
        {
            Console.WriteLine("\nAdd a Task\n");
            StreamWriter outFile = File.AppendText(filename);
            Console.Write("Enter a Task: ");
            string item = Console.ReadLine();
            outFile.WriteLine(item);
            outFile.Close();
        }


        static void removeItem()
        {
            int choice;
            showList();
            Console.Write("Which Task do you want to remove? ");
            choice = Convert.ToInt32(Console.ReadLine());
            List<string> items = new List<string>();
            int number = 1;
            string item;
            StreamReader inFile = new StreamReader(filename);
            while (inFile.Peek() != -1)
            {
                item = inFile.ReadLine();
                if (number != choice)
                    items.Add(item);
                ++number;
            }
            inFile.Close();
            StreamWriter outFile = new StreamWriter(filename);
            for (int i = 0; i < items.Count; ++i)
                outFile.WriteLine(items[i]);
            outFile.Close();
        }


        static int menu()
        {
            int choice;
            Console.WriteLine("Task Menu\n");
            Console.WriteLine("0. Exit the Task Tracker");
            Console.WriteLine("1. Display Task list");
            Console.WriteLine("2. Add Task to Task list");
            Console.WriteLine("3. Remove Task from Task list");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }


        static void showList()
        {
            Console.WriteLine("\nTask List\n");
            StreamReader inFile = new StreamReader(filename);
            string line;
            int number = 1;
            while (inFile.Peek() != -1)
            {
                line = inFile.ReadLine();
                Console.Write(number + " ");
                Console.WriteLine(line);
                ++number;
            }
            Console.WriteLine();
            inFile.Close();
        }


    }
}
