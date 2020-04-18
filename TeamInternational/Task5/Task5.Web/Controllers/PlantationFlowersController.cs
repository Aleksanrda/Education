using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.Api.Services;
using Task5.Core.Entities;

namespace Task5.Web.Controllers
{
    public class PlantationFlowersController : Controller
    {
        private readonly IPlantationFlowersService plantationFlowersService;

        public PlantationFlowersController(
            IPlantationFlowersService plantationFlowersService)
        {
            this.plantationFlowersService = plantationFlowersService;
        }

        public ActionResult Index()
        {
            var model = plantationFlowersService.GetPlantationFlowers();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = plantationFlowersService.GetPlantationFlowerById(id);

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
        public ActionResult Create(PlantationFlower plantationFlower)
        {
            
            if (ModelState.IsValid)
            {
                var newPlantationFlower = plantationFlowersService.Create(plantationFlower);
                return RedirectToAction("Details", new { id = newPlantationFlower.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = plantationFlowersService.GetPlantationFlowerById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlantationFlower plantationFlower)
        {
            if (ModelState.IsValid)
            {
                plantationFlowersService.Update(plantationFlower);

                return RedirectToAction("Details", new { id = plantationFlower.Id });
            }

            return View(plantationFlower);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = plantationFlowersService.GetPlantationFlowerById(id);

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
            plantationFlowersService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}