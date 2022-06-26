namespace KitchenBook.Domain.RecipeModel;

public class Tag
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Tag( string name )
    {
        Name = name;
    }
}
