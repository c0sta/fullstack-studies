using System;
namespace GradeBook
{
    class Program
    { 
        static void Main(string[] args)
        {
            var book = new Book("El libro");
            book.GradeAdded += OnGradeAdded;

            var done = false;

            while(!done) 
            {
                System.Console.WriteLine("Insira uma nota ou aperte 'q' para sair: ");
                var input = System.Console.ReadLine();

                if(input == "q")
                {
                    break;
                }
                try 
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            
            var stats = book.GetStatistics();


            book.ShowStatistics(stats);


        }
            static void OnGradeAdded(object sender, EventArgs e) 
            {
                System.Console.WriteLine("A grade was added");
            }
    } 
}
