using System;
using System.Collections.Generic;
using System.Linq;

namespace AdjacencyList
{
    public class DiGraph
    {
        private Dictionary<(int from, int to), Edge> _paths = new();
        private Dictionary<int, HashSet<int>> _adjList = new();

        public Edge Create(int from, int to)
        {
            if (!_adjList.ContainsKey(from))
            {
                _adjList[from] = new HashSet<int>();
            }

            _adjList[from].Add(to);
            var newPath = new Edge(from, to);
            _paths[(from, to)] = newPath;
            return newPath;
        }

        public IEnumerable<Edge> Bfs(int start = 0)
        {
            if (!_adjList.ContainsKey(start))
                yield break;

            var visited = new HashSet<(int from, int to)>();
            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();

                if (_adjList.ContainsKey(curr))
                {
                    foreach (int neighbour in _adjList[curr])
                    {
                        var edge = (curr, neighbour);
                        if (!visited.Contains(edge) && _paths.ContainsKey(edge))
                        {
                            visited.Add(edge);
                            yield return _paths[edge];
                            queue.Enqueue(neighbour);
                        }
                    }
                }
            }
        }
    }
}