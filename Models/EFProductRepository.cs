using TurulFoods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurulFoods.Models
{
    public class EFProductRepository : IProductRepo
    {
        private DataContext context;

        public EFProductRepository(DataContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;
    }
}
