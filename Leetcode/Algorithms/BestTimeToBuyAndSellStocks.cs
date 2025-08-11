using System.Text;
using Xunit;

namespace Leetcode.Algorithms;

public sealed class BestTimeToBuyAndSellStocks
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length == 0)
        {
            return 0;
        }
        var maxProfit = 0;
        var minPrice = prices[0];
        foreach (var price in prices.Skip(1))
        {
            var profit = price - minPrice;
            maxProfit = Math.Max(profit, maxProfit);
            minPrice = Math.Min(price, minPrice);
        }

        return maxProfit;
    }

    [Theory]
    [ClassData(typeof(TestData))]
    public void MaxProfit_Test(int[] input, int profit)
    {
        var result = MaxProfit(input);
        Assert.Equal(profit, result);
    }
    
    private class TestData : TheoryData<int[], int>
    {
        public TestData()
        {
            Add([7,1,5,3,6,4], 5);
            Add([7,6,4,3,1], 0);
        }
    }
}