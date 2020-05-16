using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BabyMobile.Provider
{
    public class ServerProvider
    {
        private static HttpClient client = new HttpClient();

        public static async Task<string> Post(string json, string URL)
        {
            var responseJson = string.Empty;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var serverResponse = await client.PostAsync(URL, content);
                responseJson = await serverResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex) { }
            catch (TaskCanceledException ex) { }

            return responseJson;
        }

        public static async Task<HttpStatusCode> Post(string URL)
        {
            var responseStatus = HttpStatusCode.NotFound;
            var client = new HttpClient();
            var content = new StringContent(string.Empty);
            try
            {
                var serverResponse = await client.PostAsync(new Uri(URL), content);
                responseStatus = serverResponse.StatusCode;
            }
            catch (HttpRequestException ex) { }
            catch (TaskCanceledException ex) { }

            return responseStatus;
        }

        public static async Task<string> Get(string URL)
        {
            var responseJson = string.Empty;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            try
            {
                var response = await client.GetAsync(URL);
                responseJson = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("StoreProvider.Get(URL) line 63: ERROR:" + ex.Message);
            }
            return responseJson;
        }

        public static async Task<string> Delete(string URL)
        {
            var responseJson = string.Empty;

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json-patch+json");

            try
            {
                var response = await client.DeleteAsync(URL);
                responseJson = await response.Content.ReadAsStringAsync();
            }
            catch { }
            return responseJson;
        }
    }
}
