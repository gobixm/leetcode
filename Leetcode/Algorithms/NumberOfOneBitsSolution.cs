using Xunit;

namespace Leetcode.Algorithms;

public sealed class NumberOfOneBitsSolution
{
    public int HammingWeight(int n)
    {
        var total = 0;
        for (int i = 0; i < 32; i++)
        {
            total += n & 1;
            n >>= 1;
        }

        return total;
    }

    [Theory]
    [InlineData(11, 3)]
    [InlineData(128, 1)]
    [InlineData(2147483645, 30)]
    public void HammingWeight_Test(int num, int expected)
    {
        Assert.Equal(HammingWeight(num), expected);
    }
}