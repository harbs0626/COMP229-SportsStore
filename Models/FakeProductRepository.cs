using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    /// <summary>
    /// Dependency injection
    /// </summary>
    public class FakeProductRepository /*: IProductRepository*/
    {
        public IQueryable<Product> Products => new List<Product>
        {
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
                 Category = "Water Sports"
             },
             new Product
             {
                 Name = "Running shoes",
                 Description = "Land",
                 Price = 95,
                 Category = "Running Sports"
             }
        }.AsQueryable<Product>();
    }
}
