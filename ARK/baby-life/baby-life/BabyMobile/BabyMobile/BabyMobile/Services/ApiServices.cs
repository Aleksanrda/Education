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

            var response = await client.PostAsync("https://6a2e3bcd.ngrok.io/api/Account/register", content);

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

            var response = await client.PostAsync("https://6a2e3bcd.ngrok.io/api/Account/login", content);

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

            var response = await client.PostAsync("https://6a2e3bcd.ngrok.io/api/Account/loginCarePerson", content);

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

        public async Task<bool> PostBabyAsync(Baby baby, string URL)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var model = new PostBabyModel()
            {
                Name = baby.Name,
                GenderType = baby.GenderType,
                BloodType = baby.BloodType,
                Allergies = baby.Allergies,
                Notes = baby.Notes,
            };

            var json = JsonConvert.SerializeObject(model);

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(URL, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<HttpResponseMessage> PutBabyAsync(Baby baby, string URL)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var json = JsonConvert.SerializeObject(baby);

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(URL, content);

            return response;
        }

        public async Task<bool> DeleteBabyAsync(string URL)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var response = await client.DeleteAsync(URL);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Reminder>> GetRemindersAsync(string URL)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");
            //var httpDeleteUrl = string.Format("{0}{1}/{2}", constants.Constants.ServerHostURL, DevicesHttpUrl, this.SelectedDevice.DeviceId);

            var reminders = await client.GetAsync(URL);

            var responseJson = await reminders.Content.ReadAsStringAsync();
            var remindersList = JsonConvert.DeserializeObject<List<Reminder>>(responseJson);

            return remindersList;
        }

        public async Task<bool> PostReminderAsync(Reminder reminder, string URL)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var model = new PostReminderModel()
            {
                ReminderType = reminder.ReminderType,
                ReminderTime = reminder.ReminderTime,
                Infa = reminder.Infa,
            };

            var json = JsonConvert.SerializeObject(model);

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(URL, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<HttpResponseMessage> PutReminderAsync(Reminder reminder, string URL)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var json = JsonConvert.SerializeObject(reminder);

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(URL, content);

            return response;
        }

        public async Task<bool> DeleteReminderAsync(string URL)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            var response = await client.DeleteAsync(URL);

            return response.IsSuccessStatusCode;
        }
    }
}
