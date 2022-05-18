using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenBook.Api.ApiMessages
{
    public class RecipeDto
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int CookingTime { get; private set; }
        public int Portions { get; private set; }
        public int Stars { get; private set; }
        public int Likes { get; private set; }
        
        public RecipeDto(string title, string description, int cookingTime, int portions, int stars, int likes)
        {
            Title = title;
            Description = description;
            CookingTime = cookingTime;
            Portions = portions;
            Stars = stars;
            Likes = likes;
        }
    }
}
