namespace Records.Modifiable;

public record Person(string Name, string FavoriteColor)
{
    public string Name { get; set; } = Name;
    public string FavoriteColor { get; set; } = FavoriteColor;
}
