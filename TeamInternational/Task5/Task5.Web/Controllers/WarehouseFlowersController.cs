using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.Api.Services;
using Task5.Core.Entities;

namespace Task5.Web.Controllers
{
    public class WarehouseFlowersController : Controller
    {
        private readonly IWarehouseFlowersService warehouseFlowersService;

        public WarehouseFlowersController(IWarehouseFlowersService warehouseFlowersService)
        {
            this.warehouseFlowersService = warehouseFlowersService;
        }

        public ActionResult Index()
        {
            var model = warehouseFlowersService.GetWarehouseFlowers();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = warehouseFlowersService.GetWarehouseFlowerById(id);

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
        public ActionResult Create(WarehouseFlower warehouseFlower)
        {

            if (ModelState.IsValid)
            {
                var newWarehouseFlower = warehouseFlowersService.Create(warehouseFlower);
                return RedirectToAction("Details", new { id = newWarehouseFlower.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = warehouseFlowersService.GetWarehouseFlowerById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WarehouseFlower warehouseFlower)
        {
            if (ModelState.IsValid)
            {
                warehouseFlowersService.Update(warehouseFlower);

                return RedirectToAction("Details", new { id = warehouseFlower.Id });
            }

            return View(warehouseFlower);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = warehouseFlowersService.GetWarehouseFlowerById(id);

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
            warehouseFlowersService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}