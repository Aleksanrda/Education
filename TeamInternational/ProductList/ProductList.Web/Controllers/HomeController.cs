using ProductList.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductList.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductsService productData;

        public HomeController(IProductsService productData)
        {
            this.productData = productData;
        }
        public ActionResult Index()
        {
            var model = Session["Products"];
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}