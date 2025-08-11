using System;
using System.IO;

namespace Assignment13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 1: Directory & File Operations");
            PerformDirectoryOperations();

            Console.WriteLine("\nTASK 2: File Menu using FileStream & StreamWriter/Reader");
            ShowFileMenu();
        }

        // ------------------- TASK 1 -------------------
        static void PerformDirectoryOperations()
        {
            string basePath = "demo";
            string path1 = Path.Combine(basePath, "demo1");
            string path2 = Path.Combine(basePath, "demo2");

            // Create folders
            Directory.CreateDirectory(path1);
            Directory.CreateDirectory(path2);

            // Create files
            string file1 = Path.Combine(path1, "file1.txt");
            string file2 = Path.Combine(path1, "file2.txt");

            File.WriteAllText(file1, "This is file1 using File class.");

            FileInfo fInfo = new FileInfo(file2);
            using (StreamWriter sw = fInfo.CreateText())
            {
                sw.WriteLine("This is file2 using FileInfo class.");
            }

            // Copy file1 to demo2
            string copyTarget = Path.Combine(path2, "copied_file1.txt");
            File.Copy(file1, copyTarget, true);

            // Display all files & folders with creation time
            Console.WriteLine("\nAll Directories:");
            foreach (string dir in Directory.GetDirectories(basePath, "*", SearchOption.AllDirectories))
            {
                Console.WriteLine(dir + " | Created on: " + Directory.GetCreationTime(dir));
            }

            Console.WriteLine("\nAll Files:");
            foreach (string file in Directory.GetFiles(basePath, "*", SearchOption.AllDirectories))
            {
                Console.WriteLine(file + " | Created on: " + File.GetCreationTime(file));
            }

            // Delete all files
            foreach (string file in Directory.GetFiles(basePath, "*", SearchOption.AllDirectories))
            {
                File.Delete(file);
            }

            // Delete all directories
            Directory.Delete(basePath, true);
            Console.WriteLine("\nAll files and directories deleted.");
        }

        // ------------------- TASK 2 -------------------
        static void ShowFileMenu()
        {
            string filePath = "sample.txt";
            int choice;

            do
            {
                Console.WriteLine("\n1. Create new file");
                Console.WriteLine("2. Add contents to file");
                Console.WriteLine("3. Append contents to file");
                Console.WriteLine("4. Display contents line by line");
                Console.WriteLine("5. Display full content");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            using (FileStream fs = new FileStream(filePath, FileMode.Create))
                            {
                                Console.WriteLine("File created.");
                            }
                            break;

                        case 2:
                            using (StreamWriter sw = new StreamWriter(filePath, false))
                            {
                                Console.Write("Enter content: ");
                                string content = Console.ReadLine()!;
                                sw.WriteLine(content);
                            }
                            Console.WriteLine("Content written.");
                            break;

                        case 3:
                            using (StreamWriter sw = new StreamWriter(filePath, true))
                            {
                                Console.Write("Enter content to append: ");
                                string content = Console.ReadLine()!;
                                sw.WriteLine(content);
                            }
                            Console.WriteLine("Content appended.");
                            break;

                        case 4:
                            if (!File.Exists(filePath))
                            {
                                Console.WriteLine("File not found.");
                                break;
                            }
                            using (StreamReader sr = new StreamReader(filePath))
                            {
                                string line;
                                Console.WriteLine("File content line by line:");
                                while ((line = sr.ReadLine()!) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                            break;

                        case 5:
                            if (File.Exists(filePath))
                            {
                                string data = File.ReadAllText(filePath);
                                Console.WriteLine("File content:\n" + data);
                            }
                            else
                            {
                                Console.WriteLine("File not found.");
                            }
                            break;

                        case 0:
                            Console.WriteLine("Exiting menu.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            } while (choice != 0);
        }
    }
}

