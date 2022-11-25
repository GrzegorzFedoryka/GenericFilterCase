namespace GenericFilterCase.Entities;
public class Parts
{

    public int ParentId { get; set; }
    public int ChildId { get; set; }

    public Parent Parent { get; set; } = new();
    public Child Child { get; set; } = new();
}
