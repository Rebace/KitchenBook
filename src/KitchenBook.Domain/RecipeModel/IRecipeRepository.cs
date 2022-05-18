using KitchenBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenBook.Infrastructure.Repository
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipeList();
        /*Task<Recipe>*/Recipe GetById(int id);
        Recipe Create(Recipe todo);
        void Delete(Recipe todo);
        void Update(Recipe todo);
    }
}