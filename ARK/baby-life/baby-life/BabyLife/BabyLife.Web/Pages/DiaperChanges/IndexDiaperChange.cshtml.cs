using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Api.DiaperChanges;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class IndexDiaperChangeModel : PageModel
    {
        private readonly IDiaperChangesService diaperChangesService;
        private readonly IBabiesService babiesService;

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public List<DiaperChange> DiaperChanges { get; set; }

        public IndexDiaperChangeModel(IDiaperChangesService diaperChangesService,
            IBabiesService babiesService)
        {
            this.diaperChangesService = diaperChangesService;
            this.babiesService = babiesService;
        }

        public void OnGet(int id)
        {
            Id = id;
            DiaperChanges = diaperChangesService.GetBabyDiaperChanges(id);
        }
    }
}