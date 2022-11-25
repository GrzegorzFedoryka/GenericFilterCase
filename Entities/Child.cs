namespace GenericFilterCase.Entities;
public class Child 
{
    public int Id { get; set; }
    public ICollection<Filter> Filters { get; set; } = new List<Filter>();
}