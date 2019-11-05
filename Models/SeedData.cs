using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Football",
                        Description = "Land",
                        Price = 25,
                        Category = "Ball Sports"
                    },
                    new Product
                    {
                        Name = "Surf board",
                        Description = "Water",
                        Price = 179,
                        Category = "Watersports"
                    },
                    new Product
                    {
                        Name = "Running shoes",
                        Description = "Land",
                        Price = 95,
                        Category = "Running Sports"
                    },
                    new Product
                    {
                        Name = "Football2",
                        Description = "Land",
                        Price = 25,
                        Category = "Ball Sports"
                    },
                    new Product
                    {
                        Name = "Surf board2",
                        Description = "Water",
                        Price = 179,
                        Category = "Watersports"
                    },
                    new Product
                    {
                        Name = "Running shoes2",
                        Description = "Land",
                        Price = 95,
                        Category = "Running Sports"
                    },
                    new Product
                    {
                        Name = "Football3",
                        Description = "Land",
                        Price = 25,
                        Category = "Ball Sports"
                    },
                    new Product
                    {
                        Name = "Surf board3",
                        Description = "Water",
                        Price = 179,
                        Category = "Watersports"
                    },
                    new Product
                    {
                        Name = "Running shoes3",
                        Description = "Land",
                        Price = 95,
                        Category = "Running Sports"
                    },
                    new Product
                    {
                        Name = "Football4",
                        Description = "Land",
                        Price = 25,
                        Category = "Ball Sports"
                    },
                    new Product
                    {
                        Name = "Surf board4",
                        Description = "Water",
                        Price = 179,
                        Category = "Watersports"
                    },
                    new Product
                    {
                        Name = "Running shoes4",
                        Description = "Land",
                        Price = 95,
                        Category = "Running Sports"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
