namespace Model.Graph;

public class Neighboor
{
    public Vertex Vertex { get; }
    public int? EdgeWeight { get; }

    public Neighboor(Vertex vertex, int? edgeWeight)
    {
        Vertex = vertex;
        EdgeWeight = edgeWeight;
    }
}
