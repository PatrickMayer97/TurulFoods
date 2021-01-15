using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurulFoods.Models;
using TurulFoods.Models.ViewModels;

namespace TurulFoods.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo repository;
        public ProductController(IProductRepo repo)
        {
            repository = repo;
        }
        //takes in the list of items add to cart
        public ViewResult List(string category)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID),
                
                CurrentCategory = category
            });
    }
}