using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MyRecipes.Models;

namespace MyRecipes
{
    
    class RestService
    {
        HttpClient client;
        List<RecipeEntry> RecipesList;
        RecipeEntry Recipe;

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<RecipeEntry> GetRecipe(string recipename)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, recipename));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Recipe = JsonConvert.DeserializeObject<RecipeEntry>(content);
            }
            return Recipe;
        }


        public async Task<List<RecipeEntry>> RefreshDataAsync()
        {


            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                RecipesList = JsonConvert.DeserializeObject<List<RecipeEntry>>(content);
            }
            return RecipesList;

        }

        public async Task SaveMyRecipesItemAsync(RecipeEntry item, bool isNewItem = false)
        {
            
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				MyRecipesItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteMyRecipesItemAsync(string id)
        {
           
            var uri = new Uri(string.Format(Constants.RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				MyRecipesItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }



    }
}
