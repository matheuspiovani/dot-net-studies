using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book (string name)
        {
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            try
            {
                throw new ArgumentException($"Invalid grade! {nameof(grade)}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("**");
            }
        }

        public void AddLetterGrade(char letter)
        {
            double grade;
            if(letter == 'A')
            {
                grade = 90;
            }
            else if(letter == 'B')
            {
                grade = 80;
            }
            else {
                switch(letter)
                {
                    case 'C':
                        grade = 70;
                        break;
                    case 'D':
                        grade = 60;
                        break;
                    case 'E':
                        grade = 50;
                        break;
                    default:
                        grade = 0;
                        break;
                }
            }

            AddGrade(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

/*
            // Do while
            var index = 0;
            if(grades.Count == 0) {
                return result;
            }
            do{
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index += 1;
            } while(index < grades.Count);


            // While
            result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            index = 0;
            while(index < grades.Count)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index += 1;
            }

            // For
            result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            for(index = 0; index < grades.Count; index += 1)
            {
                // Not calling anything here kkk
                if(false) {
                    break;
                } else if (false) {
                    continue;
                }

                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }
*/
            // Foreach
            result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            foreach(double grade in grades) {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'E';
                    break;
            }

            return result;
        }

        List<double> grades = new List<double>(); //This works to initialize too
//        private string name;
        public string Name;
    }
}
