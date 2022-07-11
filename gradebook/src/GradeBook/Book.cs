using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book (string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
            //if()
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(double number in grades) {
                lowGrade = Math.Min(number, lowGrade);
                highGrade = Math.Max(number, highGrade);
                result += number;
            }
            result /= grades.Count;

            Console.WriteLine($"The min grade is {lowGrade} and the max grade is {highGrade}");
            Console.WriteLine($"The average is {result:N2}");
        }

        List<double> grades = new List<double>(); //This works to initialize too
        private string name;
    }
}