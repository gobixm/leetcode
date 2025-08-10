using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class ZigZag
{
    private string Convert(string s, int numRows) {
        if (s.Length == 0 || numRows == 0)
        {
            return string.Empty;
        }

        var chars = new char[s.Length, numRows];
        var cursor = 0;
        bool diag = false;
        var indexX = 0;
        while (cursor < s.Length)
        {
            if (diag)
            {
                for (int i = numRows - 1 - 1; i >= 1; i--)
                {
                    indexX += 1;
                    chars[indexX, i] = s[cursor];
                    cursor += 1;
                    if (cursor >= s.Length)
                    {
                        break;
                    }
                }
                indexX += 1;
                diag = false;
            }
            else
            {
                for (int i = 0; i < numRows; i++)
                {
                    chars[indexX, i] = s[cursor];
                    cursor += 1;
                    if (cursor >= s.Length)
                    {
                        break;
                    }
                }
                diag = true;
            }
        }

        var result = new StringBuilder();
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j <= indexX; j++)
            {
                if (chars[j, i] != default)
                {
                    result.Append(chars[j, i]);
                }
            }
        }
        return result.ToString();
    }

    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 3, "A")]
    public void ZigZag_Test(string input, int rowNumber, string expected)
    {
        var result = Convert(input, rowNumber);
        Assert.Equal(expected, result);
    }
}