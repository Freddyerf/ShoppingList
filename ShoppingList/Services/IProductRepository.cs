using ShoppingList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(Guid productId);
        void AddProduct(Product product);

        bool Save();
    }
}
