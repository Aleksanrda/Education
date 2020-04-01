using ProductList.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductList.DAL.Services
{
    public interface IProductsService
    {
        Product Get(int id, List<Product> list);

        Product Update(Product product, List<Product> list);
    }
}
