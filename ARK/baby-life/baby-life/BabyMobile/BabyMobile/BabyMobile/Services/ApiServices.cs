using BabyMobile.Models;
using BabyMobile.ViewModels;
using CommonServiceLocator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BabyMobile.Services
{
    public class ApiServices
    {
        public async Task<string> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var model = new RegisterModel
            {
                Email = email,
                Year = DateTime.UtcNow,
                Password = password,
                PasswordConfirm = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);


            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://a73cfc45.ngrok.io/api/Account/register", content);

            var resultResponse = await response.Content.ReadAsStringAsync();

            return resultResponse;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var model = new AuthModel
            {
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(model);

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://a73cfc45.ngrok.io/api/Account/login", content);

            //var resultResponse = await response.Content.ReadAsStringAsync();

            return "Ok";
        }

        //public async Task<List<Baby>> GetBabiesAsync(string accessToken)
        //{
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

        //    var babies = 
        //}
    }
}
