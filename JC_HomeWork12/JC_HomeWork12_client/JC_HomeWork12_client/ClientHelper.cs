using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JC_HomeWork12_client
{
    public static class ClientHelper
    {
        // Helper method for comunication with server
        public static async Task<R> CallAsync<R>(
            string controller,
            string parameter)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54781/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = null;

                response = await client.GetAsync(
                    string.Format("{0}/{1}", controller,parameter));

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<R>();
            }
        }
    }
}
