﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingChart.DataAccess.Data
{
    public  class ApplicationDbContext:IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext >option):base(option) 
        
        {
            
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
