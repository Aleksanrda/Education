using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Feedings;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web.Pages.Feedings
{
    public class IndexFeedingModel : PageModel
    {
        private readonly IFeedingsService feedingsService;
        private readonly IBabiesService babiesService;

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public List<Feeding> Feedings { get; set; }

        public IndexFeedingModel(IFeedingsService feedingsService,
            IBabiesService babiesService)
        {
            this.feedingsService = feedingsService;
            this.babiesService = babiesService;
        }

        public void OnGet(int id)
        {
            Id = id;
            Feedings = feedingsService.GetBabyFeedings(id);
        }
    }
}