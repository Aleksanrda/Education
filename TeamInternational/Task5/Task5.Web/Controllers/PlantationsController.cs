using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.Api.Services;
using Task5.Core.Entities;

namespace Task5.Web.Controllers
{
    public class PlantationsController : Controller
    {
        private readonly IPlantationsService plantationsService;

        public PlantationsController(IPlantationsService plantationsService)
        {
            this.plantationsService = plantationsService;
        }

        public ActionResult Index()
        {
            var model = plantationsService.GetPlantations();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = plantationsService.GetPlantationById(id);

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
        public ActionResult Create(Plantation plantation)
        {
            if (ModelState.IsValid)
            {
                var newPlantation = plantationsService.Create(plantation);
                return RedirectToAction("Details", new { id = newPlantation.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = plantationsService.GetPlantationById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Plantation plantation)
        {
            if (ModelState.IsValid)
            {
                plantationsService.Update(plantation);

                return RedirectToAction("Details", new { id = plantation.Id });
            }

            return View(plantation);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = plantationsService.GetPlantationById(id);

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
            plantationsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}