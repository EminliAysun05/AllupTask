using Academy.Mvc.Consume.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace Academy.Mvc.Consume
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseModel> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

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
