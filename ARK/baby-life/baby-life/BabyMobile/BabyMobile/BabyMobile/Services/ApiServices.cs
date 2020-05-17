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
using Xamarin.Essentials;

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

            var response = await client.PostAsync("https://88346a15.ngrok.io/api/Account/register", content);

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

            var response = await client.PostAsync("https://88346a15.ngrok.io/api/Account/login", content);

            var resultResponse = await response.Content.ReadAsStringAsync();

            return resultResponse;
        }

        public async Task<string> LoginCarePersonAsync(int shareCode)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var model = new AuthCarePersonModel
            {
               ShareCode = shareCode
            };

            var json = JsonConvert.SerializeObject(model);

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://88346a15.ngrok.io/api/Account/loginCarePerson", content);

            var resultResponse = await response.Content.ReadAsStringAsync();

            return resultResponse;
        }

        public async Task<List<Baby>> GetBabiesAsync(string URL)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            //var httpDeleteUrl = string.Format("{0}{1}/{2}", constants.Constants.ServerHostURL, DevicesHttpUrl, this.SelectedDevice.DeviceId);

            var babies = await client.GetAsync(URL);

            var responseJson = await babies.Content.ReadAsStringAsync();
            var babiesList = JsonConvert.DeserializeObject<List<Baby>>(responseJson);

            return babiesList;
        }
    }
}
