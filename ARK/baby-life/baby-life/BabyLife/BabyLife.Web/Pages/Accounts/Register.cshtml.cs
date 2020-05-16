using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using BabyLife.Api.Accounts;
using BabyLife.Api.Accounts.AccountsModel;
using BabyLife.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BabyLife.Web
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountsService accountsService;

        [BindProperty]
        public RegisterViewModel Model { get; set; }

        public RegisterModel(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                accountsService.MyEvent += Notify;
                var result = await accountsService.Register(Model);

                if (result != null)
                {
                    return RedirectToPage("/Babies/Home");
                }
                else
                {
                    ModelState.AddModelError("Login", "User already exsists with this login");
                }
            }

            return Page();
        }

        static private void Notify(string email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("oleksandra.kryvko@nure.ua");
                mail.To.Add(email);
                mail.Subject = "BabyLife";
                mail.Body = "You are registered successfully";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("oleksandra.kryvko@nure.ua", "23Dfnhei5");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}