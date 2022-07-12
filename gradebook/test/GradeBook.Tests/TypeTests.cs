using System;
using Xunit;

namespace GradeBook.Tests;

public class TypeTests
{
    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        var x = GetInt();
        SetInt(ref x);

        Assert.Equal(x, 42);
    }

    private void SetInt(ref int z)
    {
        z = 42;
    }

    private int GetInt()
    {
        return 3;
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        // But is a ref
        string name = "Scott";
        var upper = MakeUppercase(name);

        Assert.Equal("Scott", name);
        Assert.Equal("SCOTT", upper);
    }

    private string MakeUppercase(string parameter)
    {
        return parameter.ToUpper();
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
        var book1 = GetBook("Book 1");
        // GetBookSetName(ref book1, "New Name");
        GetBookSetName(out book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    // private void GetBookSetName(ref Book book, string name)
    private void GetBookSetName(out Book book, string name)
    {
        book = new Book(name);
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);

        Assert.NotSame(book1, book2);
    }

    Book GetBook(string name)
    {
        return new Book(name);
    }

    [Fact]
    public void TwoVarsCansReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }
}
