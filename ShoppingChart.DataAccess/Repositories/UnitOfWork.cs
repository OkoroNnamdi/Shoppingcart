using ShoppingChart.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingChart.DataAccess.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository category { get; private set; }

        public IProductRepository product { get ; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            category = new CategoryRepository(context);
            product = new ProductRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
