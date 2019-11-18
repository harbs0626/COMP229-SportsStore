using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDBContext context;

        public EFProductRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product productEntry = context.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);

                if (productEntry != null)
                {
                    productEntry.Name = product.Name;
                    productEntry.Description = product.Description;
                    productEntry.Price = product.Price;
                    productEntry.Category = product.Category;
                }
            }

            context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product productEntry = context.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (productEntry != null)
            {
                context.Products.Remove(productEntry);
                context.SaveChanges();
            }

            return productEntry;
        }
    }
}
