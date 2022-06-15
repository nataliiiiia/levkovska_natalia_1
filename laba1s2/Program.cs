using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;


namespace laba1s2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
            Console.Clear();
            Task2();
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
            Console.Clear();
            Task3();
            Console.WriteLine("Press any button to exit");
            Console.ReadKey();
        }
        static void Task1()
        {
            Console.WriteLine("TASK 1");
            Console.WriteLine("Enter the number of numbers you want:");
            int Count = int.Parse(Console.ReadLine());
            List<int> Numbers = new(Count);
            for (int i = 0; i < Count; i++)
            {
                Numbers.Add(Random(Numbers));
            }
            Console.Write("The list of numbers is: ");
            for (byte i = 0; i < Numbers.Count; i++)
            {
                Console.Write(Numbers[i] + " ");
            }
            Console.WriteLine();
            Console.Write("Choose the number you want to move: ");
            int NumberToMove = int.Parse(Console.ReadLine());
            Console.Write("Now choose the position of the number: ");
            int PositionOfNumber = int.Parse(Console.ReadLine());
            if (PositionOfNumber > Numbers.Count)
            {
                Console.WriteLine("This position doesn't exist. Try again.");
            }
            else
            {
                
                if (Numbers.Contains(NumberToMove)==true)
                {
                    Numbers.Remove(NumberToMove);
                    Numbers.Insert(PositionOfNumber - 1, NumberToMove);
                    for (int i = 0; i < Numbers.Count; i++)
                        Console.WriteLine(Numbers[i]);
                }
                else Console.WriteLine("This number doesn't exist in the list. Try again.");
            }
        }
        static int Random(List<int> numbers)
        {
            int number;
            Random num = new Random();
            number = num.Next(1, 20);
            while (numbers.Contains(number) == true)
                number = num.Next(1, 20);
            return number;
        }
        static void Task2()
        {
            Console.WriteLine("TASK 2");
            Dictionary<int, int> Dictionary = new()
            {
                {1, 35},
                {2, 7 },
                {3, 1},
                {4, 68 },
                {5, 10 }
            };
            Console.WriteLine("The dictionary is: ");
            foreach (var i in Dictionary)
            {
                Console.WriteLine($"The key is: {i.Key}, The number is: {i.Value}");
            }
            int ProductOfKeys = 1;
            foreach (var i in Dictionary)
            {
                ProductOfKeys *= i.Key;
            }
            Console.WriteLine($"\nThe product of keys: {ProductOfKeys}");
            var SortedDictionary = from d in Dictionary
                         orderby d.Value
                         select d;
            Console.WriteLine("Sorted dictionary: ");
            foreach (var v in SortedDictionary)
            {
                Console.WriteLine(v);
            }
            string JsonResult = JsonSerializer.Serialize(SortedDictionary);
            Console.WriteLine("\nSerialised dictionary: " + JsonResult);
        }
        static void Task3()
        {
            Console.WriteLine("TASK 3");
            List<string> cities = new List<string>{ "Paris", "London", "Washington", "Berlin", "Sofia" };
            
            Console.WriteLine("\nThe list of cities: ");
            foreach(string city in cities)
            {
                Console.WriteLine(city);
            }
            string capitals = cities.Aggregate("Capitals: ",(caps, next) => caps + next[0]);
            Console.WriteLine("\n"+capitals);               
        }

        

    }
}
