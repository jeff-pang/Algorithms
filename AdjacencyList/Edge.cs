namespace AdjacencyList
{
    public class Edge
    {
        public int To { get; }
        public int From { get; }
        public Edge(int from, int to)
        {
            From = from;
            To = to;
        }
    }
}