using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class ValidPalindrome
{
    public bool IsPalindrome(string s)
    {
        s = s.ToLower();
        var i = 0;
        var j = s.Length - 1;
        while (i < j)
        {
            var a = s[i];
            var b = s[j];
            if (!IsAlphaNum(a))
            {
                i++;
                continue;
            }
            
            if (!IsAlphaNum(b))
            {
                j--;
                continue;
            }
            
            if (a != b)
            {
                return false;
            }

            i++;
            j--;
        }

        return true;
    }
    
    private static bool IsAlphaNum(char s)
    {
        return s is >= '0' and <= '9' or >= 'a' and <= 'z';
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("0P", false)]
    public void ValidPalindrome_Test(string s, bool valid)
    {
        Assert.Equal(IsPalindrome(s), valid);
    }
}