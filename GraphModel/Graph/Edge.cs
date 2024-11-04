namespace Model.Graph
{
    public class Edge
    {
        public Vertex Start { get; }
        public Vertex End { get; }
        public int? Weight { get; set; }

        public Edge(Vertex start, Vertex end, int weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Start} -> {End}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Edge edge)
            {
                return Start.Id == edge.Start.Id && End.Id == edge.End.Id && Weight == edge.Weight;
            }

            return false;
        }
    }
}
