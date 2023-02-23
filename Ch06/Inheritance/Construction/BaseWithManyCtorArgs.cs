namespace Construction;

public record PropertiesInCtor(int Id, string Name, double Width);

public record MoreCtorProps(int Id, string Name, double Width, int X)
    : PropertiesInCtor(Id, Name, Width);

public record YetMore(int Id, string Name, double Width, int X, int Y)
    : MoreCtorProps(Id, Name, Width, X);

public record EvenMore(int Id, string Name, double Width, int X, int Y, int Z)
    : YetMore(Id, Name, Width, X, Y);
