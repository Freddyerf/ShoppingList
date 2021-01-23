using Microsoft.EntityFrameworkCore;
using ShoppingList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Data
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
    }
}
