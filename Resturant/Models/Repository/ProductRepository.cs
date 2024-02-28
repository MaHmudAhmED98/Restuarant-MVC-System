
using Microsoft.EntityFrameworkCore;
using Resturant.Models;
using Resturant.Models.Context;

namespace RestaruantMVC.Models.Reprositray
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectContext context;

        public ProductRepository(ProjectContext context)
        {
            this.context = context;
        }

        public void Delete(int productId)
        {
            context.Remove(GetById(productId));
        }

        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public Products GetById(int productId)
        {
            return context.Products.FirstOrDefault(c => c.Id == productId);
        }

        public List<Products> GetByType(productType type)
        {
            return context.Products.Where(c=> c.Type == type).ToList();
        }

        public void Insert(Products product)
        {
            context.Add(product);
        }

        public void savechanges()
        {
            context.SaveChanges();
        }

        public void Update(Products product)
        {
            context.Update(product);
        }
    }
}