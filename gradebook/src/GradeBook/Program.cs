using System;
using System.Collections.Generic;

namespace GradeBook {
    class Program {
        static void Main(string[] args) {
            // Initializing variables
            var x = 3.1415;
            double y = 3.1415;

            double [] numbers = new double[3];
            var numbersInitialized = new [] { 1.1, 2.2, 3.3 };

            var result = x + y;
            numbers[0] = x;
            numbers[1] = y;
            numbers[2] = result;

            var result2 = 0.0;
            foreach(double number in numbersInitialized) {
                result2 += number;
            }

            // Lists
            var grades = new List<double>();
            grades.Add(1.1);
            grades.Add(1.2);
            grades.Add(1.6);
            result = 0;
            foreach(double number in grades){
                result += number;
                Console.WriteLine(number);
            }
            result /= grades.Count;

            if(args.Length > 0) {
                Console.WriteLine("Hello " + args[0] + "!");

                // String interpolation
                Console.WriteLine($"Hello {args[0]}!");
            }
            else {
                Console.WriteLine("Hello void!");
            }

            Console.WriteLine($"The result is {result:N2}");
        }
    }
}
