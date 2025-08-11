using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class ThreeSumm
{
    private IList<IList<int>> ThreeSum(int[] nums)
    {
        nums = nums.Order().ToArray();
        List<IList<int>> triplets = [];
        for(var i=0; i< nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            
            var target = -nums[i];
            var j = i + 1;
            var k = nums.Length - 1;
            while (j < k)
            {
                if (j - 1 > i && nums[j] == nums[j - 1])
                {
                    j++;
                    continue;
                }
                
                if (k + 1 < nums.Length - 1 && nums[k] == nums[k + 1])
                {
                    k--;
                    continue;
                }
                
                if (nums[j] + nums[k] == target)
                {
                    triplets.Add([nums[i],nums[j],nums[k]]);
                    j++;
                    k--;
                }
                else
                {
                    if ((nums[j] + nums[k]) > target)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }

        return triplets;
    }

    private IList<IList<int>> ThreeSumSlow(int[] nums)
    {
        var valuesIndices = nums.GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count());
        List<IList<int>> triplets = [];
        foreach (var one in valuesIndices)
        {
            var x = one.Key;
            var xdupes = one.Value;

            foreach (var two in valuesIndices)
            {
                var y = two.Key;
                
                // skip x if no dupe
                if (y == x && xdupes == 1)
                {
                    continue;
                }

                var z = -(x + y);
                if (valuesIndices.TryGetValue(z, out var dupes))
                {
                    if (z == x)
                    {
                        dupes -= 1;
                    }
                    
                    if (z == y)
                    {
                        dupes -= 1;
                    }

                    if (dupes > 0)
                    {
                        List<int> result = [x,y,z];
                        result.Sort();
                        triplets.Add(result);
                    }
                }
            }
        }

        var equalityComparer = EqualityComparer<IList<int>>.Create((x, y) =>
            x![0] == y![0] && x[1] == y[1] && x[2] == y[2], ints => 0);
        return triplets.Distinct(equalityComparer)
            .ToList();
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void ThreeSumm_Test(int[] input, IList<IList<int>> expected)
    {
        var result = ThreeSum(input);
        Assert.Equal(expected, result);
    }
    
    private class TestData : TheoryData<int[], IList<IList<int>>>
    {
        public TestData()
        {
            Add([0, 0, 0],[[0,0,0]]);
            Add([-1,0,1,2,-1,-4],[[-1,-1,2], [-1,0,1]]);
            Add([0,1,1],[]);
        }
    }
}