using System.ComponentModel.DataAnnotations;
using Resturant.Models;

namespace RestaruantMVC.Models.ViewModel
{
    public class ProductViewModel
    {
        [Display(Name ="product ID")]

        public int producId { get; set; }

        [Display(Name ="product Name")]
        public string ProductName { get; set; }

        [Display(Name = "product Description")]
        public string ProductDescription { get; set; }

        [Display(Name ="product Type")]
        public productType? ProdectType { get; set; }

        [Display(Name = "product price")]
        public decimal Price { get; set; }

        public IFormFile File { get; set; }
        public byte[]? Image {  get; set; }
        public static ProductViewModel FromDbModel(Products product)
        {
            return new ProductViewModel
            {
                
                producId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                Price = product.price,
                Image = product.image,
                ProdectType = product.Type,
            };
        }

        //public static ProductViewModel FromDbModel2(ProductViewModel model)
        //{
        //    return new Products
        //    {

        //        Name = model.ProductName,
        //        Description = model.ProductDescription,
        //        price = model.Price,
        //        image = model.Image,
        //        Type = model.ProdectType,
        //    };
        //}
    }
}
