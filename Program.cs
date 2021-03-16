using System;
using System.Collections.Generic;
using System.IO;

namespace CollierFirlus_1322Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class: 1322L
            //Section: 06
            //Term: Fall 2020
            //Instructor: Peter Adeojo
            //Name: Collier Firlus
            //Lab#: 12
            StreamWriter sw = null;
            StreamReader sr = null;
            int Lines = 0, Words = 0, Chars = 0;
            try
            {
                Console.WriteLine("This program gives the number of words, characters and number of lines in a file.");
                Console.Write("Type in the name of the file you want to get information on: ");
                string FileName = Console.ReadLine();
                sr = new StreamReader(FileName);

                Console.WriteLine();

                string Text;
                string SplitAt = " ";
                string[] WordsArray;

                while (!sr.EndOfStream)
                {
                    Lines++; //lines count

                    Text = sr.ReadLine();
                    WordsArray = Text.Split(SplitAt.ToCharArray()); //words count
                    Words += WordsArray.Length;

                    for (int x = 0; x< WordsArray.Length; x++) //chars count
                    {
                        Chars += WordsArray[x].Length;
                    }
                }
                Console.WriteLine("Total lines = " + Lines);

                Console.WriteLine("Total words = " + Words);

                Console.WriteLine("Total chars = " + Chars);
                Console.WriteLine();

                Console.Write("Enter output.txt save location (YOU MUST END DIRECTORY PATH WITH output.txt!): ");
                string OutputLocation = Console.ReadLine();

                sw = File.CreateText(OutputLocation); //File.CreateText method found through Microsoft .NET documentation
                sw.WriteLine("The file statistics are as follows:");
                sw.WriteLine("Total lines = " + Lines);
                sw.WriteLine("Total words = " + Words);
                sw.WriteLine("Total chars = " + Chars);

                Console.WriteLine("Generated output.txt at " + OutputLocation);
            }
            catch(IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (sw != null) sw.Close();
                if (sr != null) sr.Close();
            }
        }
    }
}
