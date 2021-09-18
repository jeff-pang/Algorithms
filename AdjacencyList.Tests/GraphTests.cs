using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AdjacencyList.Tests
{
    public class GraphTests
    {
        private readonly ITestOutputHelper _output;

        public GraphTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void breadth_first_traversal()
        {
            var graph = new Graph();
            graph.Create(0, 1);
            graph.Create(0, 2);
            graph.Create(1, 2);
            graph.Create(2, 3);
            graph.Create(3, 0);

            var expected = new List<(int from, int to)>
            {
                (0, 1),
                (0, 2),
                (1, 2),
                (2, 3),
                (3, 0)
            };

            Assert.Equal(expected, graph.Bfs().Select(p=>(p.From,p.To)));
        }
    }
}