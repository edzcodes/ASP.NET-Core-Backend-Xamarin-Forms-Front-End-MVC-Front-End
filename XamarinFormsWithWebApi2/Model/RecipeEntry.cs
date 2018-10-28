using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET.Model
{
    public class RecipeEntry 
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeID { get; set; }
        
        public string RecipeName { get; set; }
        
        public string Category { get; set; }
        public string Ingredients { get; set; }
        public string Recipe { get; set; }
        public string Notes { get; set; }
        public string ImageFilePath { get; set; }

      
        //public RecipeEntry()
        //{
        //    RecipeID = 0;
        //    RecipeName = "test";
        //    Category = null;
        //    Ingredients = null;
        //    Recipe = null;
        //    Notes = null;
        //    ImageFilePath = null;
        //}
  
    }
}
