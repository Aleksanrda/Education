using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Bathings;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class IndexBathingModel : PageModel
    {
        private readonly IBathingsService bathingsService;
        private readonly IBabiesService babiesService;


        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public List<Bathing> Bathings { get; set; }

        public IndexBathingModel(IBathingsService bathingsService,
            IBabiesService babiesService)
        {
            this.bathingsService = bathingsService;
            this.babiesService = babiesService;
        }

        public void OnGet(int id)
        {
            Id = id;
            Bathings = bathingsService.GetBabyBathings(id);
        }
    }
}