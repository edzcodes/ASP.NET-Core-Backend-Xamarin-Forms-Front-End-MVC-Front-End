using ASP.NET.Data;
using ASP.NET.Model;
using System.Collections.Generic;

namespace ASP.NET.Repositories
{
    public interface IRecipesRepository
    {

       // RecipeContext RecipeContext { get; }

         IEnumerable<RecipeEntry> GetRecipesList();
         RecipeEntry GetRecipe(int id);
         string CreateRecipe(RecipeEntry recipe);
         string DeleteRecipe(int id);
         void EditRecipe(int id, RecipeEntry recipe);


        //bool DoesItemExist(string id);
        //IEnumerable<MyRecipesItem> All { get; }
        //MyRecipesItem Find(string id);
        //void Insert(MyRecipesItem item);
        //void Update(MyRecipesItem item);
        //void Delete(string id);

    }
}