using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET.Data;
using ASP.NET.Model;
namespace ASP.NET.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private RecipeContext RecipeContext { get; }
        


        public RecipesRepository(RecipeContext recipeContext)
        {
            RecipeContext = recipeContext;
        }



        public string CreateRecipe(RecipeEntry recipe)
        {
          
                RecipeContext.Recipes.Add(recipe);
                RecipeContext.SaveChanges();
                if (RecipeContext.SaveChanges() == 1)
                {
                    return "Save Successful";
                }
                else { return "Save Failed"; }
            
         
        }

        public string DeleteRecipe(int id)
        {
           
                var recipe =  RecipeContext.Recipes.Find(id);
                RecipeContext.Recipes.Remove(recipe);
                RecipeContext.SaveChanges();
                if (RecipeContext.SaveChanges() == 1)
                {
                    return "Delete Successful";
                }
                else { return "Delete Failed"; }
            
               
        }

        public IEnumerable<RecipeEntry> GetRecipesList()
        {
            
                try
                {
                    return RecipeContext.Recipes.ToList();
                }
                catch
                {
                    return null;
                }
            
            
            
     
           
           // var myList = database.Table<RecipeEntry>().Where(e => e.RecipeName.Contains(key)).OrderBy(c => c.RecipeName).ToList();
            //            return myList;
        }

        public RecipeEntry GetRecipe(int id)
        {
           
            return RecipeContext.Recipes.FirstOrDefault(r => r.RecipeID == id);
            
               
        }


        public void EditRecipe(int id, RecipeEntry recipe)
        {
                var editRecipe =  RecipeContext.Recipes.Find(id);
                
                editRecipe = recipe;
                RecipeContext.Recipes.Update(editRecipe);
                RecipeContext.SaveChanges();
            
         
        }

      
    }
}
