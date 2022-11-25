namespace GenericFilterCase.Entities;
public class Parent
{
    public int Id { get; set; }
    public ICollection<Part> Parts { get; set; }
}
