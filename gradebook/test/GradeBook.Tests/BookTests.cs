using System;
using Xunit;

namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void Test1()
    {
        // arrange
        var book = new Book("");
        book.AddGrade(1.123);
        book.AddGrade(2.487);
        book.AddGrade(3.666);

        // act
        var result = book.GetStatistics();

        // assert
        Assert.Equal(2.4253, result.Average, 4);
        Assert.Equal(3.666, result.High, 4);
        Assert.Equal(1.123, result.Low, 4);
    }
}
