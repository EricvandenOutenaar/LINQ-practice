using System;

namespace JustSomeExperiments
    {
    class Program
        {
        static void Main(string[] args)
            {
            
            var myList = new CustomCollection<string>();
            myList.Add("Test").Add("Making").Add("This class").Add("Enumerable"); 
            
            foreach(var word in myList)
                {
                    Console.WriteLine($"{word}");
                }
            }
        }
    }
