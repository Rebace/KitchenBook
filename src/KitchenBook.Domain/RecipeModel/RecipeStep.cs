namespace KitchenBook.Domain.RecipeModel;

public class RecipeStep
{
    public int Id { get; private set; }
    public string Content { get; private set; }
    public int RecipeId { get; private set; }
    public Recipe Recipe { get; private set; }

    public RecipeStep( string content )
    {
        Content = content;
    }
}
