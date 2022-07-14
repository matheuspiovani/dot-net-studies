using System;
using Xunit;

namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
        // arrange
        var book = new InMemoryBook("");
        book.AddGrade(70.123);
        book.AddGrade(20.487);
        book.AddGrade(90.666);

        // act
        var result = book.GetStatistics();

        // assert
        Assert.Equal(60.4253, result.Average, 4);
        Assert.Equal(90.666, result.High, 4);
        Assert.Equal(20.487, result.Low, 4);
        Assert.Equal('D', result.Letter);
    }
}
