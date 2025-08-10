using Xunit;

namespace Leetcode.Algorithms;

public sealed class  ContainerWithMostWater
{
    private int MaxArea(int[] height)
    {
        var indexL = 0;
        var indexR = height.Length - 1;
        var maxArea = 0;

        while (indexL != indexR)
        {
            var area = Math.Min(height[indexL], height[indexR]) * (indexR - indexL);
            if (area > maxArea)
            {
                maxArea = area;
            }

            var currentL = height[indexL];
            var currentR = height[indexR];

            if (currentL <= currentR)
            {
                indexL += 1;
            }
            else
            {
                indexR -= 1;
            }
        }

        return maxArea;
    }
    
    [Theory]
    [ClassData(typeof(TestData))]
    public void MaxArea_Test(int[] heigths, int area)
    {
        var result = MaxArea(heigths);
        Assert.Equal(area, result);
    }

    private class TestData : TheoryData<int[], int>
    {
        public TestData()
        {
            Add([1, 8, 6, 2, 5, 4, 8, 3, 7], 49);
            Add([1, 1], 1);
            Add([1,2,4,3], 4);
            Add([8,7,2,1], 7);
            Add([3,6,1], 3);
            Add([1,2,3,1000,9], 9);
            Add([1,8,100,2,100,4,8,3,7], 200);
        }
    }
}