using Resturant.Models;

namespace RestaruantMVC.Models.Reprositray
{
    public interface IProductRepository
    {
        public List<Products> GetAll();
        public Products GetById(int productId);
        public List<Products> GetByType(productType type);
        public void savechanges();
        public void Insert(Products product);
        public void Update(Products product);
        public void Delete(int productId);

    }
}
