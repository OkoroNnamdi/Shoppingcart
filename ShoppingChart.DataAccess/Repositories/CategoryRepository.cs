using ShoppingCart.Models;
using ShoppingChart.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingChart.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context ): base(context )
        {
            _context = context;
        }
        public void Update(Category category)
        {
          var categoryDb = _context.categories.FirstOrDefault (x => x.Id == category.Id);
            if (categoryDb != null)
            {
                //categoryDb.Name = category.Name;
                //categoryDb.DisplayOrder = category.DisplayOrder;
                _context.categories.Update(category);

            }
        }
    }
}
