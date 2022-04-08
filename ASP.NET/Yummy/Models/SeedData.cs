using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Yummy.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YummyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<YummyContext>>()))
            {
                // Look for any movies.
                if (context.Recipes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Recipes.AddRange(
                    new Recipes
                    {
                        Name = "Recipe 1",
                        Time = 30,
                        Difficulty = "easy",
                        LikesNumber = 5,
                        Ingredients = "ingr 1, ingr 2, ingr 3",
                        Process = "Do nothing",
                        TipsTricks = "Happy meal"
                    },

                    new Recipes
                    {
                        Name = "Recipe 2",
                        Time = 45,
                        Difficulty = "easy",
                        LikesNumber = 123,
                        Ingredients = "ingr 1, ingr 2, ingr 3",
                        Process = "Do nothing",
                        TipsTricks = "Happy meal"
                    },

                    new Recipes
                    {
                        Name = "Recipe 3",
                        Time = 15,
                        Difficulty = "easy",
                        LikesNumber = 1,
                        Ingredients = "ingr 1, ingr 2, ingr 3",
                        Process = "Do nothing",
                        TipsTricks = "Happy meal"
                    },

                    new Recipes
                    {
                        Name = "Recipe 4",
                        Time = 10,
                        Difficulty = "easy",
                        LikesNumber = 27,
                        Ingredients = "ingr 1, ingr 2, ingr 3",
                        Process = "Do nothing",
                        TipsTricks = "Happy meal"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}