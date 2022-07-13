using System;
using System.Collections.Generic;

namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            var book = new Book("My Grade Book");

            do
            {
                Console.WriteLine("Enter a grade or 'q' to exit");
                var input = Console.ReadLine();
                Console.WriteLine(input);
                if(input == "q")
                {
                    break;
                }

                var grade = double.Parse(input);
                book.AddGrade(grade);
            } while(true == true && false != true);

            var stats = book.GetStatistics();

            Console.WriteLine($"The min grade is {stats.Low} and the max grade is {stats.High}");
            Console.WriteLine($"The average is {stats.Average:N2}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

            if(args.Length > 0) {
                Console.WriteLine("Hello " + args[0] + "!");

                // String interpolation
                Console.WriteLine($"Hello {args[0]}!");
            }
            else {
                Console.WriteLine("Hello void!");
            }
        }
    }
}
