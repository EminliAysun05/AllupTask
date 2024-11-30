using Academy.Mvc.Consume.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace Academy.Console1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var response = await GetAsync("https://localhost:7259/api/Students/1");

            Console.WriteLine(response);
        }

        public static async Task<ResponseModel> GetAsync(string url)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseAsJson = await response.Content.ReadAsStringAsync();

                var responseModel = JsonConvert.DeserializeObject<ResponseModel>(responseAsJson);
                return responseModel;
            }

            return JsonConvert.DeserializeObject<ResponseModel>("");
        }
    }
}
