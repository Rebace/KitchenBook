using KitchenBook.Api.ApiMessages;
using KitchenBook.Api.MessageContracts;
using KitchenBook.Api.MessageContracts.Mappers;
using KitchenBook.Domain;
using KitchenBook.Infrastructure.Repository;
using KitchenBook.Infrastructure.UoF;
using Microsoft.AspNetCore.Mvc;

namespace KitchenBook.Api.Controllers
{
    [Route("recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            List<Recipe> recipes = _recipeRepository.GetRecipeList();
            return Ok(recipes.Select(x => x.Map()));
        }

        [HttpGet]
        [Route("{recipeId}")]
        public IActionResult GetById(int recipeId)
        {
            Recipe? recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe.Map());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] RecipeDto recipeDto)
        {
            //Если без мапинга или надо просто  создавать объект используя recipeDto?
            var createdRecipe = _recipeRepository.Create(new Recipe(recipeDto.Title, recipeDto.Description,
                recipeDto.CookingTime, recipeDto.Portions, recipeDto.Stars, recipeDto.Likes));
            _unitOfWork.Commit();

            return Ok(createdRecipe.Id);
        }

        [HttpDelete]
        [Route("{recipeId}/delete")]
        public IActionResult Delete(int recipeId)
        {
            Recipe? recipe = _recipeRepository.GetById(recipeId);

            if (recipe == null)
            {
                return BadRequest();
            }
            else
            {
                _recipeRepository.Delete(recipe);

                _unitOfWork.Commit();

                return NoContent();
            }
        }
    }
}
