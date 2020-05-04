using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyLife.Api.Babies;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class BabyProfileModel : PageModel
    {
        private readonly IBabiesService babiesService;
        private readonly UserManager<User> userManager;

        public List<Baby> Babies { get; set; }

        public BabyProfileModel(IBabiesService babiesService,
             UserManager<User> userManager)
        {
            this.babiesService = babiesService;
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var userId = userManager.GetUserId(User);
                
            Babies = babiesService.GetUserBabies(userId).ToList();
        }
    }
}