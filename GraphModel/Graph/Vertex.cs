namespace Model.Graph;

public class Vertex
{
    public int Id { get; }
    
    public Vertex(int id)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"{Id+1}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vertex vertex)
        {
            return this.Id == vertex.Id;
        }
        return base.Equals(obj);
    }

    public static bool operator ==(Vertex x, Vertex y) => x.Equals(y);
    public static bool operator !=(Vertex x, Vertex y) => !x.Equals(y);
}
