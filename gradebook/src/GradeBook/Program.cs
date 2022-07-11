using System;
using System.Collections.Generic;

namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            var book = new Book("My Grade Book");
            book.AddGrade(1.1);
            book.AddGrade(7.1);
            book.AddGrade(4.18979);
            var stats = book.GetStatistics();

            Console.WriteLine($"The min grade is {stats.Low} and the max grade is {stats.High}");
            Console.WriteLine($"The average is {stats.Average:N2}");

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
