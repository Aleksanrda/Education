using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.Api.Services;
using Task5.Core.Entities;

namespace Task5.Web.Controllers
{
    public class SupplyFlowersController : Controller
    {
        private readonly ISupplyFlowersService supplyFlowersService;

        public SupplyFlowersController(ISupplyFlowersService supplyFlowersService)
        {
            this.supplyFlowersService = supplyFlowersService;
        }

        public ActionResult Index()
        {
            var model = supplyFlowersService.GetSupplyFlowers();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = supplyFlowersService.GetSupplyFlowerById(id);

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
        public ActionResult Create(SupplyFlower supplyFlower)
        {

            if (ModelState.IsValid)
            {
                var newSupplyFlower = supplyFlowersService.Create(supplyFlower);
                return RedirectToAction("Details", new { id = newSupplyFlower.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = supplyFlowersService.GetSupplyFlowerById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplyFlower supplyFlower)
        {
            if (ModelState.IsValid)
            {
                supplyFlowersService.Update(supplyFlower);

                return RedirectToAction("Details", new { id = supplyFlower.Id });
            }

            return View(supplyFlower);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = supplyFlowersService.GetSupplyFlowerById(id);

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
            supplyFlowersService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}