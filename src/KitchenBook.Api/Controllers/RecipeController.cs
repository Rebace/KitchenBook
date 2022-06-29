﻿using KitchenBook.Api.ApiMessages;
using KitchenBook.Api.MessageContracts.Mappers;
using KitchenBook.Domain;
using KitchenBook.Domain.UserModel;
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
        private readonly IUserRepository _userRepository;

        public RecipeController(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            List<Recipe> recipes = await _recipeRepository.GetRecipeList();
            return Ok(recipes.Select(x => x.Map()));
        }

        [HttpGet]
        [Route("{recipeId}")]
        public async Task<IActionResult> GetById(int recipeId)
        {
            Recipe recipe = await _recipeRepository.GetById(recipeId);
            return Ok(recipe.Map());
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] RecipeDto recipeDto)
        {
            string login = HttpContext.Request.Cookies["Login"];
            User user = await _userRepository.GetByLogin(login);

            var createdRecipe = await _recipeRepository.Create(new Recipe(
                recipeDto.Title,
                recipeDto.Description,
                recipeDto.CookingTime,
                recipeDto.Portions,
                recipeDto.Stars,
                recipeDto.Likes,
                0
            ));
            _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        [Route("{recipeId}/delete")]
        public async Task<IActionResult> Delete(int recipeId)
        {
            Recipe recipe = await _recipeRepository.GetById(recipeId);

            _recipeRepository.Delete(recipe);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}
