using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurulFoods.Models
{
    public class FakeRepo : IProductRepo
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Football", Description = "HI"}
        }.AsQueryable<Product>();
    }
}
