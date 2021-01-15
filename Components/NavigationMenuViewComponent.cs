using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurulFoods.Models;

namespace TurulFoods.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepo repository;

        public NavigationMenuViewComponent(IProductRepo repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
