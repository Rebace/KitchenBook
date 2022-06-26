using KitchenBook.Domain.RecipeModel;
using System.ComponentModel.DataAnnotations;

namespace KitchenBook.Domain;

public class Recipe
{
    [Key]
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int CookingTime { get; private set; }
    public int Portions { get; private set; }
    public int Stars { get; private set; }
    public int Likes { get; private set; }
    public List<TagRecipe> Tags { get; private set; }
    public List<RecipeStep> RecipeSteps { get; private set; }
    public List<RecipeIngredient> RecipeIngredients { get; private set; }
    public int UserId { get; private set; }

    // Workaround for EF
    protected Recipe()
    {
    }

    public Recipe(string title, string description, int cookingTime, int portions, int stars, int likes, int userId, List<Tag> tags, List<RecipeStep> steps, List<RecipeIngredient> ingredients)
    {
        Title = title;
        Description = description;
        CookingTime = cookingTime;
        Portions = portions;
        Stars = stars;
        Likes = likes;
        UserId = userId;
        RecipeSteps = steps;
        RecipeIngredients = ingredients;
        Tags = tags;
    }
}
