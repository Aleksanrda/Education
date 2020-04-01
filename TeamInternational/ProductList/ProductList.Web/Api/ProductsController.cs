using ProductList.DAL.Models;
using ProductList.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductList.Web.Api
{
    public class ProductsController : ApiController
    {
        private readonly IProductsService productData;

        public ProductsController(IProductsService productData)
        {
            this.productData = productData;
        }
    }
}
