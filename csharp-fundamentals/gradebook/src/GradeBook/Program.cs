
namespace GradeBook
{
    class Program
    { 
        static void Main(string[] args)
        {
            var book = new Book("El libro");
            book.AddGrade(83.12);      
            book.AddGrade(90.5);      
            book.AddGrade(837);      

            book.ShowStatistics();            

        }
    }
}
