using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurulFoods.Models;

namespace TurulFoods.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepo repo;
        
        public HomeController(IProductRepo repository)
        {
            repo = repository;
        }
        //calls each page
        public IActionResult Index()
        {
            return View(repo.Products);
        }

        public IActionResult OurMenu()
        {
            return View(repo.Products);
        }

        public IActionResult UserPage()
        {
            return View(repo.Products);
        }

        public IActionResult Events()
        {
            return View(repo.Products);
        }

        
        
    }
}