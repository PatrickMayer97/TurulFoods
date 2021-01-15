using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TurulFoods.Infrastructure;
using TurulFoods.Models;
using TurulFoods.Models.ViewModels;

namespace TurulFoods.Controllers
{
    public class CartController : Controller
    {
        private IProductRepo repository;
        private Cart cart;

        public CartController(IProductRepo repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Order() => View();



        public IActionResult CartIndex(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });

            
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

           

            if (product != null)
            {
                //Cart cart = GetCart();
                cart.AddItem(product, 1);
                //SaveCart(cart);
            }
            return RedirectToAction("CartIndex", new { returnUrl });
        }
        
        
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                //Cart cart = GetCart();
                cart.RemoveLine(product);
                //SaveCart(cart);
                
            }
            return RedirectToAction("CartIndex", new { returnUrl });
        }

        
    }
}