using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurulFoods.Models;

namespace TurulFoods.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        //private IProductRepo repo;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
            
        }
        public ViewResult Checkout() => View(new Order());
        public ViewResult Order() => View();


        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                //repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            } 
            else
            {
                return View(order);
            }

            
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}