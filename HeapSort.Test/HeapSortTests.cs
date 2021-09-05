using System;
using System.Linq;
using Xunit;

namespace HeapSort.Test
{
    public class HeapSortTests
    {
        [Fact]
        public void heapify()
        {
            int[] source = new[] { 1, 2, 3, 4, 5, 6, 7, 16, 9, 10, 11, 12, 13, 14, 15, 8 };
            var sorter = new Sorter();
            sorter.BuildHeap(source);
            int[] expected = new[] { 16, 11, 15, 9, 10, 13, 14, 8, 2, 1, 5, 12, 6, 3, 7, 4 };
            Assert.Equal(expected,source);
        }

        [Fact]
        private void sort()
        {
            int[] source = new[] { 1, 2, 3, 4, 5, 6, 7, 16, 9, 10, 11, 12, 13, 14, 15, 8 };
            int[] expected = source.OrderBy(s => s).ToArray();
            var sorter = new Sorter();
            sorter.Sort(source);
            Assert.Equal(expected, source);
        }
    }
}