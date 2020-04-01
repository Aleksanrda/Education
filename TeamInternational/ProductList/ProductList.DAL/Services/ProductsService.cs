using ProductList.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductList.DAL.Services
{
    public class ProductsService : IProductsService
    {
        public Product Get(int id, List<Product> list)
        {
            return list.FirstOrDefault(p => p.Id == id);
        }

        public Product Update(Product product, List<Product> list)
        {
            var currentProduct = Get(product.Id, list);

            if(currentProduct != null)
            {
                currentProduct.Name = product.Name;
                currentProduct.Count = product.Count;
                currentProduct.Measure = product.Measure;
            }

            return currentProduct;
        }
    }
}
