using System;
using System.Linq;
using Xunit;

namespace CountingSort.Tests
{
    public class CountingSortTests
    {
        [Fact]
        public void sort()
        {
            int[] source = new[] { 3, 0, 2, 0, 0, 2, 2 };
            int[] expected = source.OrderBy(s => s).ToArray();
            var sorter = new Sorter();
            sorter.Sort(source, 4);
            
            Assert.Equal(expected,source);
        }
    }
}