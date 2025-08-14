using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class ExcelSheetColumnNumberSolution
{
    public string ConvertToTitle(int columnNumber)
    {
        var result = new StringBuilder();
        var num = columnNumber;
        while (num > 0)
        {
            num -= 1;
            var rem = num % 26;
            result.Append(ToChar(rem));
            num /= 26;
        }

        return string.Join("", result.ToString().Reverse());
    }

    private char ToChar(int num)
    {
        return (char)('A' + num);
    }

    [Theory]
    [InlineData(1, "A")]
    [InlineData(28, "AB")]
    [InlineData(701, "ZY")]
    public void ConvertToTitle_Test(int column, string title)
    {
        Assert.Equal(ConvertToTitle(column), title);
    }
}