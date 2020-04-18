using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.Api.Services;
using Task5.Core.Entities;

namespace Task5.Web.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly ISuppliesService suppliesService;

        public SuppliesController(ISuppliesService suppliesService)
        {
            this.suppliesService = suppliesService;
        }

        public ActionResult Index()
        {
            var model = suppliesService.GetSupplies();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = suppliesService.GetSupplyById(id);

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
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supply supply)
        {

            if (ModelState.IsValid)
            {
                var newSupply = suppliesService.Create(supply);
                return RedirectToAction("Details", new { id = newSupply.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = suppliesService.GetSupplyById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supply supply)
        {
            if (ModelState.IsValid)
            {
                suppliesService.Update(supply);

                return RedirectToAction("Details", new { id = supply.Id });
            }

            return View(supply);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = suppliesService.GetSupplyById(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            suppliesService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}