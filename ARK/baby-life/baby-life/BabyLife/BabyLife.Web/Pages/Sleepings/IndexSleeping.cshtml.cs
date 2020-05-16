using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.Sleepings;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class IndexSleepingModel : PageModel
    {
        private readonly ISleepingsService sleepingsService;
        private readonly IBabiesService babiesService;


        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public List<Sleeping> Sleepings { get; set; }

        public IndexSleepingModel(ISleepingsService sleepingsService,
            IBabiesService babiesService)
        {
            this.sleepingsService = sleepingsService;
            this.babiesService = babiesService;
        }

        public void OnGet(int id)
        {
            Id = id;
            Sleepings = sleepingsService.GetBabySleepings(id);
        }
    }
}