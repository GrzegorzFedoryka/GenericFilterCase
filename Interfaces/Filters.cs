namespace GenericFilterCase.Interfaces;

using GenericFilterCase.Entities;

public interface IFilterable
{

}

public interface IFilterableByParent : IFilterable
{
    public Parent Parent { get; set; }
}
public interface IFilterableByChild : IFilterable
{
    public Child Child { get; set; }
}
