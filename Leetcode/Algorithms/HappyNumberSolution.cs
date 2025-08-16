using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class HappyNumberSolution
{
    public bool IsHappy(int n)
    {
        var current = n;
        HashSet<int> seen = [];

        while (!seen.Contains(current))
        {
            seen.Add(current);
            current = GetSumOfSquares(current);
        }

        return current == 1;
    }

    private int GetSumOfSquares(int n)
    {
        var digits = n.ToString();
        var sum = 0;
        foreach (var digit in digits)
        {
            var value = int.Parse(digit.ToString());
            sum += value * value;
        }

        return sum;
    }

    [Theory]
    [InlineData(19, true)]
    [InlineData(2, false)]
    public void IsHappy_Test(int input, bool happy)
    {
        var result = IsHappy(input);
        Assert.Equal(happy, result);
    }
}