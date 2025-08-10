using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class Atoi
{
    private int MyAtoi(string s)
    {
        s = s.Trim();
        if (s.Length == 0)
        {
            return 0;
        }

        bool negative = false;
        if (s[0] == '-')
        {
            negative = true;
            s = s[1..];
        } else if (s[0] == '+')
        {
            s = s[1..];
        }

        s = s.TrimStart('0');
        if (s.Length == 0)
        {
            return 0;
        }
        List<int> digits = [];
        foreach (var digit in s)
        {
            if (digit is >= '0' and <= '9')
            {
                digits.Add(int.Parse(digit.ToString()));
            }
            else
            {
                break;
            }
        }

        if (!digits.Any())
        {
            return 0;
        }

        digits.Reverse();
        long sum = 0;
        long magnitude = 1;
        long maxValue = negative ? -(long)int.MinValue : int.MaxValue;
        foreach (var digit in digits)
        {
            if (magnitude > maxValue)
            {
                sum = maxValue;
                break;
            }
            sum += digit * magnitude;
            if (sum > maxValue)
            {
                sum = maxValue;
                break;
            }
            magnitude *= 10;
        }

        if (negative)
        {
            sum = -sum;
        }

        return (int)sum;
    }

    [Theory]
    [InlineData("42", 42)]
    [InlineData("-042", -42)]
    [InlineData("1337c0d3", 1337)]
    [InlineData("0-1", 0)]
    [InlineData("words and 987", 0)]
    [InlineData("-91283472332", -2147483648)]
    [InlineData("10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000522545459", 2147483647)]
    [InlineData("2147483646", 2147483646)]
    [InlineData("2147483648", 2147483647)]
    public void MyAtoI_Test(string input, int expected)
    {
        var result = MyAtoi(input);
        Assert.Equal(expected, result);
    }
}