using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class ProfileModel : PageModel
    {
        public async Task OnGet()
        {
            string[] data = new string[] {
            "Hello",
            "How are you"
            };

            Response.Headers.Add("Content-Type", "text/event-stream");

            for (int i =0; i < data.Length; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(4));
            }
        }
    }
}