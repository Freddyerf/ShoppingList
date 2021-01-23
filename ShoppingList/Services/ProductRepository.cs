using ShoppingList.Data;
using ShoppingList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services
{
    public class ProductRepository : IProductRepository
    {
        private ShoppingListContext _context;
        public ProductRepository(ShoppingListContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
        }

        public Product GetProduct(Guid productId)
        {
            return _context.Products.Where(p => p.Id == productId).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
