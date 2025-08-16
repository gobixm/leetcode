using Xunit;

namespace Leetcode.Algorithms;

public sealed class IsomorphicStringsSolution
{
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length)
        {
            return false;
        }

        var sChars = s.ToCharArray();
        var tChars = t.ToCharArray();
        
        return IsMapable(sChars, tChars) && IsMapable(tChars, sChars);
    }

    private bool IsMapable(char[] sChars, char[] tChars)
    {
        Dictionary<char, int> map = [];
        for (int i = 0; i < sChars.Length; i++)
        {
            if (map.TryGetValue(sChars[i], out var seen))
            {
                if (tChars[i] != seen)
                {
                    return false;
                }
            }
            else
            {
                map.TryAdd(sChars[i], tChars[i]);
            }
        }
        
        return true;
    }

    [Theory]
    [InlineData("egg", "add", true)]
    [InlineData("foo", "bar", false)]
    [InlineData("paper", "title", true)]
    [InlineData("badc", "baba", false)]
    public void IsIsomorphic_Test(string s, string t, bool valid)
    {
        Assert.Equal(IsIsomorphic(s,t), valid);
    }
}