using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string name;
 
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var highGrade = double.MinValue; // declara o menor valor ṕossível

            var lowGrade = double.MaxValue; // Declara o maior valor

            var result = 0.0;

            foreach(int number in grades)
            {
                if(number > highGrade)
                {
                    highGrade = Math.Max(number, highGrade); // Retorna o maior valor entre o "number" e o "highGrade"
                    lowGrade = Math.Min(number, lowGrade); // Retorna o menor valor entre o "number" e o "lowGrade"
                    result += number;

                }
            }
                result /= grades.Count;

                System.Console.WriteLine($"O menor valor da classe é: {lowGrade }");

                System.Console.WriteLine($"O maior valor da classe é: {highGrade}");

                System.Console.WriteLine($"O valor médio da classe é: {result:N1}");
             
        }



    }
}