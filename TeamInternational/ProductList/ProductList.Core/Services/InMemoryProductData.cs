using ProductList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductList.Core.Services
{
    public class InMemoryProductData : IProductData
    {
        List<Product> products;

        public InMemoryProductData()
        {
            products = new List<Product>()
            {
                new Product {Id = 1, Name = "Cheese", Count = 2, Quizine = Quizine.Pieces},
                new Product {Id = 2, Name = "Milk", Count = 0.5, Quizine = Quizine.Gram},
                new Product {Id = 3, Name = "Granola", Count = 4, Quizine = Quizine.Pieces}
            };
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products.OrderBy(p => p.Name);
        }
    }
}
