using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET.Model;
using ASP.NET.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers
{
    public class RecipeCoreController : Controller
    {
        private IRecipesRepository _recipeRepository;


        public RecipeCoreController(IRecipesRepository reciperepository)
        {
            _recipeRepository = reciperepository;
        }


        // GET: RecipeCore
        public ActionResult Index()
        {
            var allRecipes = _recipeRepository.GetRecipesList();
            return View(allRecipes);
        }

        // GET: RecipeCore/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecipeCore/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: RecipeCore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] RecipeEntry myRecipe)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _recipeRepository.CreateRecipe(myRecipe);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: RecipeCore/Edit/5
        public ActionResult Edit(int id)
        {
            var recipeEntry = _recipeRepository.GetRecipe(id);
            
            return View(recipeEntry);
        }

        // POST: RecipeCore/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeEntry recipeEdited)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _recipeRepository.EditRecipe(id, recipeEdited);
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: RecipeCore/Delete/5
        public ActionResult Delete(int id)
        {
            var recipeEntry = _recipeRepository.GetRecipe(id);
            return View(recipeEntry);
        }

        // POST: RecipeCore/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _recipeRepository.DeleteRecipe(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }
    }
}