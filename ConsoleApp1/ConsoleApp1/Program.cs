using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)    
        {            
            List<Student> list = new List<Student>();
            string line = null;            

            Console.WriteLine("Enter a path to CSV file:");
            String FilePathToCSV = Console.ReadLine();

            Console.WriteLine("Enter a destination path:");
            String DestinationPath = Console.ReadLine() + "result";
            Console.WriteLine(DestinationPath);

            Console.WriteLine("Enter data format:");
            String DataFormat = Console.ReadLine();
            DestinationPath = DestinationPath + "." + DataFormat;
            Console.WriteLine(DestinationPath);

            String LogFilePath = "/Users/radyslavburylko/tutorial2/ConsoleApp1/ConsoleApp1/log.txt";
            using (FileStream fileStream = new FileStream(LogFilePath,FileMode.Create))
            {
                try
                {
                    if (!File.Exists(FilePathToCSV))
                    {
                        AddText(fileStream, "Path to File CSV not found.");
                        throw new FileNotFoundException("CSV file does not exist.");
                    }

                    if (File.Exists(DestinationPath))
                    {
                        File.Delete(DestinationPath);
                    }
                    

                    using (FileStream fs = File.Create(DestinationPath)) 
                    using(var streamReader = new StreamReader(File.OpenRead(FilePathToCSV)))
                    {
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            string[] students = line.Split(',');

                            if (students.Length < 9)
                            {
                                continue;
                            }
                            string Course = students[2];
                            string StudiesMode = students[3];
                            var student = new Student()
                            {
                                FirstName = students[0],
                                LastName = students[1],
                                IndexNumber = students[4],
                                BirthDate = students[5],
                                Email = students[6],
                                MotherName = students[7],
                                FatherName = students[8],
                                Studies = new Studies(Course, StudiesMode){
                                    
                            }
                            }; 
                            list.Add(student);
                        }    
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("university"));
                        
                        xmlSerializer.Serialize(fs,list);
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                    AddText(fileStream,"Exception caught.");
                }
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] data = new UTF8Encoding(true).GetBytes(value);
            fs.Write(data,0,data.Length);
        }
    }
}