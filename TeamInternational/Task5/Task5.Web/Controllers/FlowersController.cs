using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.Api.Services;
using Task5.Core.Entities;

namespace Task5.Web.Controllers
{
    public class FlowersController : Controller
    {
        private readonly IFlowersService flowersService;

        public FlowersController(IFlowersService flowersService)
        {
            this.flowersService = flowersService;
        }

        public ActionResult Index()
        {
            var model = flowersService.GetFlowers();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = flowersService.GetFlowerById(id);

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
        public ActionResult Create(Flower flower)
        {
            if (ModelState.IsValid)
            {
                flowersService.Create(flower);
                return RedirectToAction("Details", new { id = flower.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = flowersService.GetFlowerById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flower flower)
        {
            if (ModelState.IsValid)
            {
                flowersService.Update(flower);

                return RedirectToAction("Details", new { id = flower.Id });
            }

            return View(flower);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = flowersService.GetFlowerById(id);

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
            flowersService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}