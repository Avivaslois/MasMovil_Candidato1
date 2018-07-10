using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.APIHelper
{
    public class APIHelper : InterfaceAPIHelper
    {
        public string apiUrl { get; set; }

        public APIHelper() { }
        public APIHelper(string url)
        {
            apiUrl = url;
        }

        private async Task<HttpResponseMessage> PrepareRequest(HttpMethod type, string endPoint, object data = null)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(apiUrl);
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Client.Timeout = new TimeSpan(0, 10, 0);

                HttpRequestMessage request = new HttpRequestMessage(type, endPoint);
                if (data != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                }

                return await ExecuteRequest(Client, request);
            }
        }

        private async Task<HttpResponseMessage> ExecuteRequest(HttpClient httpClient, HttpRequestMessage request)
        {
            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                Console.Write($"Error on request. Status: {response.StatusCode}");
            }

            return response;
        }

        public virtual async Task<T> Post<T>(string endPoint, object data)
        {
            HttpResponseMessage response = await PrepareRequest(HttpMethod.Post, endPoint, data);
            string result = await response.Content.ReadAsStringAsync();

            T value = JsonConvert.DeserializeObject<T>(result);
            return value;
        }
    }
}
