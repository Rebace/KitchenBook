using KitchenBook.Domain;
using KitchenBook.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace KitchenBook.Infrastructure.Data.RecipeModel
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _dbContext;

        public RecipeRepository(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Recipe> GetRecipeList()
        {
            return _dbContext.Recipe.ToList();
        }

        public /*async Task<Recipe>*/Recipe GetById(int id)
        {
            return /*await*/ _dbContext.Recipe./*SingleOrDefaultAsync*/SingleOrDefault(x => x.Id == id);
        }

        public Recipe Create(Recipe recipe)
        {
            var entity = _dbContext.Recipe.Add(recipe);
            return entity.Entity;
        }

        public void Delete(Recipe recipe)
        {
            _dbContext.Recipe.Remove(recipe);
        }

        public void Update(Recipe recipe)
        {
            _dbContext.Recipe.Update(recipe);
        }
    }
}
