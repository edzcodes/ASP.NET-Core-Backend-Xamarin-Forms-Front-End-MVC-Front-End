using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP.NET.Model;
using System.Reflection.Emit;

namespace ASP.NET.Data
{
    public class RecipeContext : DbContext
    {

        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)

        { }



        public DbSet<RecipeEntry> Recipes { get; set; }


    }
}
