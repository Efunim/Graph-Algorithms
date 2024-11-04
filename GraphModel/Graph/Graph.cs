namespace Model.Graph;

[Serializable]
public class Graph
{
    public bool IsDirected { get; }
    public bool IsWeighted { get; }
    public Dictionary<Vertex, IEnumerable<Neighboor>> Edges { get; } = new Dictionary<Vertex, IEnumerable<Neighboor>>();

    public Graph(bool isOriented, bool isWeighted, Dictionary<Vertex, IEnumerable<Neighboor>> edges)
    {
        IsDirected = isOriented;
        IsWeighted = isWeighted;
        Edges = edges;
    }

    public Graph(int numNodes, double edgeDensity, bool isDirected = false, bool isWeighted = false)
    {
        IsDirected = isDirected;
        IsWeighted = isWeighted;

        GenerateGraph(numNodes, edgeDensity);
    }

    public bool AddEdge(Vertex start, Vertex end, int? weight)
    {
        var neighboor = new Neighboor(end, weight);
        if(Edges.TryGetValue(start, out var neighbors))
        {
            if (neighbors.Contains(neighboor))
                return false;

            Edges[start].Append(neighboor);
        }
        else
        {
            Edges.Add(start, new List<Neighboor>() { neighboor });
        }

        return true;
    }

    public bool AddVertex(Vertex vertex)
    {
        if(Edges.ContainsKey(vertex))
        {
            return false;
        }

        Edges.Add(vertex, new List<Neighboor>());
        return true;
    }

    private void GenerateGraph(int numNodes, double edgeDensity)
    {
        var random = new Random();

        var vertices = new List<Vertex>();
        for (int i = 0; i < numNodes; i++)
        {
            var vertex = new Vertex(i);
            vertices.Add(vertex);
            AddVertex(vertex);
        }

        for (int i = 0; i < numNodes; i++)
        {
            for (int j = i + 1; j < numNodes; j++)
            {
                if (random.NextDouble() < edgeDensity)
                {
                    var start = vertices[i];
                    var end = vertices[j];

                    int? weight = IsWeighted ? random.Next(1, 11) : null;

                    AddEdge(start, end, weight);
                    if (!IsDirected)
                    {
                        AddEdge(end, start, weight);
                    }
                }
            }
        }
    }
}
