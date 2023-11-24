using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace AdventofCodeDay1
{
    public class Elves
    {
        private int ElfNumber;
        private int[] Calories;
        private int TempCalories;
        public int elfNumber
        {
            get { return ElfNumber; }
            set { ElfNumber = value; }
        }
        public int[] calories
        {
            get { return Calories; }
            set { Calories = value; }
        }
        public int tempCalories
        {
            get { return TempCalories; }
            set { TempCalories = value; }
        }
        public void ReadFile()
        {
            string filePath = (@"C:\Users\jordw\source\repos\AdventOfCode\AdventofCodeDay1\AdventofCodeDay1\input.txt");
            var lines = File.ReadAllLines(filePath);
            
            calories = new int[filePath.Length];
            tempCalories = 0;

            int i = 0;
            
            foreach (var line in lines)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        elfNumber = i + 1;
                        Console.WriteLine("Elf: " + elfNumber + "   Calories: " + calories[i]);
                        tempCalories = 0;
                        i++;
                    }
                    else if (!string.IsNullOrEmpty(line))
                    {
                        tempCalories += Int32.Parse(line);
                        calories[i] = tempCalories;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    break;
                }
            }
        }
        public void GetLargestElf()
        {
            int i, first, second, third;

            third = first = second = 000;
            for (i = 1; i < calories.Length; i++)
            {
                if (calories[i] > first)
                {
                    third = second;
                    second = first;
                    first = calories[i];
                }
                else if (calories[i] > second && calories[i] != first)
                {
                    third = second;
                    second = calories[i];
                }
                else if (calories[i] > third && calories[i] != second)
                {
                    third = calories[i];
                }
                
            }
            
            Console.WriteLine("\nTop 3 Calories...\n" + "1st... " + first);
            Console.WriteLine("\n2nd... " + second);
            Console.WriteLine("\n3nd... " + third);
            Console.ReadLine();
        }
    }
}
