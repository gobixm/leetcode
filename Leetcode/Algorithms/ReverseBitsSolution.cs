using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class ReverseBitsSolution
{
    public uint ReverseBits(uint n)
    {
        uint result = 0;
        for (int i = 0; i < 32; i++)
        {
            var bit = (n >> (31 - i)) & 1;
            result |= bit << i;
        }

        return result;
    }

    [Theory]
    [InlineData(2147483644, 1073741822)]
    [InlineData(43261596, 964176192)]
    [InlineData(2, 1073741824)]
    public void ReverseBits_Test(uint straight, uint reversed)
    {
        Assert.Equal(ReverseBits(straight), reversed);
    }
}