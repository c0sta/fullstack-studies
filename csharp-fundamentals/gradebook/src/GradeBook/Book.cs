using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public class NamedObject
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
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
    public interface IBook
    {
        public void AddGrade(double grade);

        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public delegate void GradeAddedDelegate(object sender, EventArgs args); 
    public class InMemoryBook : Book
    
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            category = "";

        }
        // Métodos
        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                AddGrade(0);
                break;
            }
        }

        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade > 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    // sender, eventArgs
                    // GradeAddedDelegate(this, new EventArgs());
                }
            }
            else {
                throw new ArgumentException($"{nameof(grade)} inválida");
            }
        }
        public override event GradeBook.GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();

                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }   
                
                return result;
            }
         

            
        }
          

        // Atributos
        private List<double> grades;
        readonly string category = "Ciencia";


    }

  public class DiskBook : Book
  {
      public DiskBook(string name) : base(name)
       {}
    public override event GradeAddedDelegate GradeAdded;

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
      throw new NotImplementedException();
    }
  }
}