namespace KitchenBook.Domain.RecipeModel;

public class RecipeIngredient
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public int RecipeId { get; private set; }
    public Recipe Recipe { get; private set; }

    public RecipeIngredient( string title, string content )
    {
        Title = title;
        Content = content;
    }
}
