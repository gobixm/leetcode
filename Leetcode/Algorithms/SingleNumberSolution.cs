using Xunit;

namespace Leetcode.Algorithms;

public sealed class SingleNumberSolution
{
    public int SingleNumber(int[] nums)
    {
        var seen = new HashSet<int>();
        foreach (var num in nums)
        {
            if (!seen.Add(num))
            {
                seen.Remove(num);
            }
        }

        return seen.Single();
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void SingleNumber_Test(int[] nums, int num)
    {
        Assert.Equal(SingleNumber(nums), num);
    }
    
    private class TestData : TheoryData<int[], int>
    {
        public TestData()
        {
            Add([4,1,2,1,2],4);
        }
    }
}