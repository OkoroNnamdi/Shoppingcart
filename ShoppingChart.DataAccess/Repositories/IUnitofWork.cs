using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingChart.DataAccess.Repositories
{
    public  interface IUnitofWork
    {
        ICategoryRepository category { get; }
        IProductRepository product { get; }

        void Save();
    }
}
