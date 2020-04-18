using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.Api.Services;
using Task5.Core.Entities;

namespace Task5.Web.Controllers
{
    public class WarehousesController : Controller
    {
        private readonly IWarehousesService warehousesService;

        public WarehousesController(IWarehousesService warehousesService)
        {
            this.warehousesService = warehousesService;
        }

        public ActionResult Index()
        {
            var model = warehousesService.GetWarehouses();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = warehousesService.GetWarehouseById(id);

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
        public ActionResult Create(Warehouse warehouse)
        {

            if (ModelState.IsValid)
            {
                var newWarehouse = warehousesService.Create(warehouse);
                return RedirectToAction("Details", new { id = newWarehouse.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = warehousesService.GetWarehouseById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                warehousesService.Update(warehouse);

                return RedirectToAction("Details", new { id = warehouse.Id });
            }

            return View(warehouse);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = warehousesService.GetWarehouseById(id);

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
            warehousesService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}