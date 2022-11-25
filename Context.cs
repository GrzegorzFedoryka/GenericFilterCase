using GenericFilterCase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace GenericFilterCase;

public class Context : DbContext
{
    public DbSet<Parent> Parents { get; set; }
    public DbSet<ParentMeasurement> ParentMeasurements { get; set; }
    public DbSet<Child> Children { get; set; }
    public DbSet<ChildMeasurement> ChildrenMeasurements { get; set; }
    public DbSet<Filter> Filters { get; set; }
    public DbSet<Part> Parts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}