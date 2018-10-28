using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRecipes.Models;
using Xamarin.Forms;

namespace MyRecipes
{
    public partial class MainPage : ContentPage
    {
        private RecipeEntry myRecipe {get; set;}
        private RestService _restService;

		public MainPage()
		{
			InitializeComponent();
            
            
		}

    

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            myRecipe = new RecipeEntry();

           // myRecipe.RecipeID = int.Parse(ID.Text);
            myRecipe.RecipeName = RecipeName.Text;
            myRecipe.Ingredients = Ingredients.Text;
            myRecipe.Notes = Notes.Text;
            myRecipe.ImageFilePath = ImageFilePath.Text;
            myRecipe.Category = Category.Text;

            _restService = new RestService();
            await _restService.SaveMyRecipesItemAsync(myRecipe, true);
        }
    }
}
