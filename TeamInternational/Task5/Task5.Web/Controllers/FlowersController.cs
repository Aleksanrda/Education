using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.Api.Services;

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
    }
}