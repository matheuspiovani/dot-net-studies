using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegated(object sender, EventArgs args);

    public class NamedObject : Object
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegated GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddedDelegated GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegated GradeAdded;
    }

    public class InMemoryBook : Book, IBook
    {
        public InMemoryBook (string name) : base(name)
        {
            grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
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

        public override event GradeAddedDelegated GradeAdded;

        public void AddGrade(char letter)
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

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach(double grade in grades) {
                result.Add(grade);
            }
            return result;
        }

        List<double> grades = new List<double>(); //This works to initialize too
//        private string name;

/*        public string Name
        {
            get;
            private set;
        }
*/
/*        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            //    else
              //  {
                //    throw new InvalidDataException($"Invalid name! {nameof(value)}");
                //}
            }
        }

        private string name;
*/
//        readonly string category = "Science";
        const string category = "Science";
//        public const string CATEGORY = "Science"; Static
    }
}
