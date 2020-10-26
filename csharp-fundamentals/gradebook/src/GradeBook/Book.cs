using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
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

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade > 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    // sender, eventArgs
                    GradeAdded(this, new EventArgs());
                }
            }
            else {
                throw new ArgumentException($"{nameof(grade)} inválida");
            }
        }
        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()

        {
            Statistics result = new Statistics();

            result.High = double.MinValue; // declara o menor valor ṕossível

            result.Low = double.MaxValue; // Declara o maior valor

            for(var index = 0; index < grades.Count; index++ )
            {
                result.High = Math.Max(grades[index], result.High); // Retorna o maior valor entre o "grade" e o "highGrade"
                result.Low = Math.Min(grades[index], result.Low); // Retorna o menor valor entre o "grade" e o "lowGrade"
                result.Average += grades[index];
                // incrementa no index
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
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public void ShowStatistics(Statistics result) {
            System.Console.WriteLine($"The average value: {result.Average}");
            System.Console.WriteLine($"The high value: {result.High}");
            System.Console.WriteLine($"The low value: {result.Low}");
            System.Console.WriteLine($"The letter value: {result.Letter}");
        }

        // Atributos
        private List<double> grades;

        private string name;
        public string Name {
            get; 
            set;
        }

        readonly string category = "Ciencia";


    }
}