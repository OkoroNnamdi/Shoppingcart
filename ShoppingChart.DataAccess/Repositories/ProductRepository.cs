using ShoppingCart.Models;
using ShoppingChart.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingChart.DataAccess.Repositories
{
    public  class ProductRepository:Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository( ApplicationDbContext context ):base( context )

        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productDb = _context.products.FirstOrDefault (product => product.Id == product.Id);
            if ( productDb != null )
            {
                productDb.Name = product.Name;
                productDb.Description = product.Description;
                productDb.Price = product.Price;
               if (product.ImageUrl != null )
                {
                    productDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
