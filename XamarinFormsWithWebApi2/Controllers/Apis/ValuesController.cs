using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET.Repositories;
using Microsoft.AspNetCore.Mvc;
using ASP.NET.Data;
using ASP.NET.Model;

namespace XamarinFormsWithWebApi2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IRecipesRepository _recipeRepository;


        public ValuesController(IRecipesRepository reciperepository)
        {
            _recipeRepository = reciperepository;
        }


       // GET api/values
       [HttpGet]
        public IEnumerable<RecipeEntry> Get()
        {
            return _recipeRepository.GetRecipesList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public RecipeEntry Get(int id)
        {
            return _recipeRepository.GetRecipe(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]RecipeEntry recipe)
        {
            _recipeRepository.CreateRecipe(recipe);
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //    _recipeRepository.EditRecipe(id);
        //}

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]RecipeEntry recipe)
        {
            _recipeRepository.EditRecipe(id, recipe);
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _recipeRepository.DeleteRecipe(id);
        }
    }
}
