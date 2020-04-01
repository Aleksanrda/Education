using ProductList.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductList.Core.Services
{
    public interface IProductData
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
    }
}
