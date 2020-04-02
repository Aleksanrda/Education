using ProductList.DAL.Models;
using ProductList.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProductList.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productData;
        public ProductsController(IProductsService productData)
        {
            this.productData = productData;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = (List<Product>)Session["Products"];

            if (model == null)
            {
                List<Product> list = new List<Product> { new Product
                {
                  Id = 1,
                  Name = "Bread",
                  Count = 2,
                  Measure = MeasureType.Pieces
                },
                new Product
                {
                  Id = 2,
                  Name = "Tortoise shell",
                  Count = 4,
                  Measure = MeasureType.Pieces
                },
                new Product
                {
                  Id = 3,
                  Name = "Dragon claw",
                  Count = 6,
                  Measure = MeasureType.Pieces
                },
                new Product
                {
                  Id = 4,
                  Name = "Eggs",
                  Count = 2,
                  Measure = MeasureType.Pieces
                },
                new Product
                {
                  Id = 5,
                  Name = "Dracula blood",
                  Count = 5,
                  Measure = MeasureType.Liter
                },
                new Product
                {
                  Id = 6,
                  Name = "Magic beans",
                  Count = 3000,
                  Measure = MeasureType.Gram
                },
                new Product
                {
                  Id = 7,
                  Name = "Pearl",
                  Count = 1,
                  Measure = MeasureType.Pieces
                }
                };
                Session["Products"] = list;
                Session["Count"] = 1;
                model = (List<Product>)Session["Products"];
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = productData.Get(id, (List<Product>)Session["Products"]);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (Session["Products"] == null)
                {
                    List<Product> products = new List<Product>();

                    product.Id = 1;

                    products.Add(product);

                    Session["Products"] = products;
                    Session["Count"] = 1;
                }
                else
                {
                    List<Product> products = (List<Product>)Session["Products"];
                    product.Id = products.Max(p => p.Id) + 1;

                    products.Add(product);

                    Session["Products"] = products;
                    Session["Count"] = Convert.ToInt32(Session["Count"]) + 1;
                }

                return RedirectToAction("Details", new { id = product.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = productData.Get(id, (List<Product>)Session["Products"]);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                List<Product> list = (List<Product>)Session["Products"];
                var currentProduct = productData.Update(product, (List<Product>)Session["Products"]);
                Session["Products"] = list;
                return RedirectToAction("Details", new { id = product.Id });
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = productData.Get(id, (List<Product>)Session["Products"]);

            if (model == null)
            {
                return View("NotFound");
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            List<Product> list = (List<Product>)Session["Products"];
            list.RemoveAll(l => l.Id == id);
            Session["Products"] = list;
            Session["Count"] = Convert.ToInt32(Session["Count"]) - 1;

            return RedirectToAction("Index");
        }
    }
}