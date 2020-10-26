using System;
namespace GradeBook
{
    class Program
    { 
        static void Main(string[] args)
    {
      var book = new InMemoryBook("El libro");
      IBook diskBook = new DiskBook("book");

      EnterGrades(book);
      var stats = book.GetStatistics();

    }

    private static void EnterGrades(IBook book)
    {
      while (true)
      {
        System.Console.WriteLine("Insira uma nota ou aperte 'q' para sair: ");
        var input = System.Console.ReadLine();

        if (input == "q")
        {
          break;
        }
        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          throw;
        }
      }
    }

    static void OnGradeAdded(object sender, EventArgs e) 
            {
                System.Console.WriteLine("A grade was added");
            }
    } 
}
