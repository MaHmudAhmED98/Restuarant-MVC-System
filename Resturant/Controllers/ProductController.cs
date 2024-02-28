using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaruantMVC.Models;
using RestaruantMVC.Models.Reprositray;
using RestaruantMVC.Models.ViewModel;
using Resturant.Models;

namespace RestaruantMVC.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
       
        //public IActionResult Getall()
        //{
        //    return View(productRepository.GetAll().Select(ProductViewModel.FromDbModel));
        //}
        public IActionResult GetAllDrinks()
        {
          return View(productRepository.GetByType(productType.drink).Select(ProductViewModel.FromDbModel));

        }
        public IActionResult GetAllMeals()
        {

            return View(productRepository.GetByType(productType.meal).Select(ProductViewModel.FromDbModel));

        }
        public IActionResult GetById(int id)
        {
            var product = productRepository.GetById(id);
            if (product == null)
            {
                throw new ArgumentException();
            }
            return View(ProductViewModel.FromDbModel(product));
        }

        [HttpGet]
        public IActionResult Add() 
        {
        
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Products pro = new Products();
            
            pro.price = model.Price;
            pro.Name = model.ProductName;
            pro.Description = model.ProductDescription;
            pro.image = model.Image;
            pro.Type = model.ProdectType;

            using (var ms = new MemoryStream())
            {
                model.File.CopyTo(ms);
                pro.image = ms.ToArray();
            }

            productRepository.Insert(pro);
            productRepository.savechanges();
            if (model.ProdectType == productType.drink) return RedirectToAction("GetAllDrinks");
             else  return RedirectToAction(nameof(GetAllMeals));
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductViewModel model = ProductViewModel.FromDbModel(productRepository.GetById(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel model, [FromRoute]int id )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Products product = productRepository.GetById(id);

            
            product.price = model.Price;
            product.Name = model.ProductName;
            product.Description = model.ProductDescription;
            product.image = model.Image;
            product.Type = model.ProdectType;
            using (var ms = new MemoryStream())
            {
                model.File.CopyTo(ms);
                product.image = ms.ToArray();
            }

            productRepository.Update(product);
            productRepository.savechanges();
            if (model.ProdectType == productType.drink) return RedirectToAction("GetAllDrinks");
            else return RedirectToAction(nameof(GetAllMeals));
        }

        public IActionResult Delete(int id)
        {
            Products product = productRepository.GetById(id);
            productRepository.Delete(id);
            productRepository.savechanges();
            if (product.Type == productType.drink) return RedirectToAction("GetAllDrinks");
            else return RedirectToAction(nameof(GetAllMeals));
        }

      
    }
}
