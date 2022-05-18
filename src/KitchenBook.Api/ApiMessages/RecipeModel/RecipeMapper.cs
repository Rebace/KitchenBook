using KitchenBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenBook.Api.ApiMessages;

namespace KitchenBook.Api.MessageContracts.Mappers
{
    public static class RecipeMapper
    {
        public static Recipe Map(this RecipeDto recipeDto)
        {
            return new Recipe
            (
                recipeDto.Title,
                recipeDto.Description,
                recipeDto.CookingTime,
                recipeDto.Portions,
                recipeDto.Stars,
                recipeDto.Likes
            );
        }
        
        public static RecipeDto Map(this Recipe recipe)
        {
            return new RecipeDto
            (
                recipe.Title,
                recipe.Description,
                recipe.CookingTime,
                recipe.Portions,
                recipe.Stars,
                recipe.Likes
            );
        }
    }
}
