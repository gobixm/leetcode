using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class IntergerToRoman
{
    private string IntToRoman(int num)
    {
        var digits = $"{num}".ToCharArray().Reverse().ToArray();
        int oneces = digits.Length > 0 ? int.Parse(digits[0].ToString()) : 0;
        int tens = digits.Length > 1 ? int.Parse(digits[1].ToString()) : 0;
        int hundrets = digits.Length > 2 ? int.Parse(digits[2].ToString()) : 0;
        int thousands = digits.Length > 3 ? int.Parse(digits[3 ].ToString()) : 0;
        var result = new StringBuilder();
        if (thousands > 0)
        {
            result.Append(ToRoman(thousands, "", "", "M"));
        }
        
        if (hundrets > 0)
        {
            result.Append(ToRoman(hundrets, "M", "D", "C"));
        }
        
        if (tens > 0)
        {
            result.Append(ToRoman(tens, "C", "L", "X"));
        }
        
        if (oneces > 0)
        {
            result.Append(ToRoman(oneces, "X", "V", "I"));
        }

        return result.ToString();
    }

    private string ToRoman(int number, string next, string nextHalf, string current)
    {
        return number switch
        {
            4 => $"{current}{nextHalf}",
            9 => $"{current}{next}",
            1 => current,
            2 => $"{current}{current}",
            3 => $"{current}{current}{current}",
            5 => $"{nextHalf}",
            6 => $"{nextHalf}{current}",
            7 => $"{nextHalf}{current}{current}",
            8 => $"{nextHalf}{current}{current}{current}",
        };
    }

    [Theory]
    [InlineData(3749, "MMMDCCXLIX")]
    [InlineData(58, "LVIII")]
    [InlineData(1994, "MCMXCIV")]
    public void IntToRoman_Test(int input, string expected)
    {
        var result = IntToRoman(input);
        Assert.Equal(expected, result);
    }
}