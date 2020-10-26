using System;
using Xunit;

namespace GradeBook.Tests
{

    
    public class TypeTests
    {

    public delegate string WriteLogDelegate(string logMessage);
    int count = 0;
    [Fact]
    public void WriteLogDelegateCanPointToMethod() 
    {
        WriteLogDelegate log = ReturnMessage;
        log += new WriteLogDelegate(ReturnMessage); // OR log = ReturnMessage;
        log += IncrementCount;
        var result = log("Logging message");

        Assert.Equal(3, count);

    }
    string IncrementCount(string message)
    {
        count++;
        return message.ToLower();
    }

    string ReturnMessage(string message)
    {
        count++;
        return message;
    }

    [Fact]
    public void StringBehaveLikeValueTypes()
    {
        string name = "Scott";
        var upper = MakeUpperCase(name);
        Assert.Equal("Scott", name);
        Assert.Equal("SCOTT", upper);

    }

    private string MakeUpperCase(string parameter)
    {
        return parameter.ToUpper();
    }

    [Fact]
    public void ValueTypesAlsoPassByValue() 
    {
        var x =  GetInt();
        SetInt(ref x);

        Assert.Equal(42, x);
    }

    private void SetInt(ref int x)
    {
        x = 42;
    }

    private int GetInt()
    {
        return 42;
    }


    [Fact]
    public void CSharpCanPassByRef()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1, book1.Name);

    }

    private void GetBookSetName(ref Book book, string name)
    {
        book = new Book(name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "Book 1");
        Assert.Equal("Book 1", book1.Name);

    }

    [Fact] // Decoration que representa um teste unitário
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");
        SetName(book1, "Book 1");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);
    }
   
    void SetName(Book book, string name)
    {
        book.Name = name;
    }

    [Fact] // Decoration que representa um teste unitário
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }
        

    Book GetBook(string name)
    {
        return new Book(name);
    }

 
  }
}
   