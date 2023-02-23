using Microsoft.EntityFrameworkCore;

namespace StandardOperators;

public class ExampleDbContext : DbContext
{
    public DbSet<Product> Product => Set<Product>();

}

public class Product
{
    public required string Name { get; set; }

    public required decimal ListPrice { get; set; }

    public required double Size { get; set; }
}