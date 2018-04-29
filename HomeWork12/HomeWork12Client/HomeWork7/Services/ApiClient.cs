using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7.Services
{
    class ApiClient
    {
        public static async Task<R> CallAsync<R>(
            string controller,
            string parameter)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56772/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = null;

                response = await client.GetAsync(
                    string.Format("{0}/{1}", controller, parameter));

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<R>();
            }
        }
    }
}
