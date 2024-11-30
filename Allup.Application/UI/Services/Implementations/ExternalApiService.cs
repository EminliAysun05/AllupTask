using Allup.Domain.Currency;
using System.Xml.Serialization;

namespace Allup.Application.UI.Services.Implementations
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;
        private string _currencyUrlBasePath = "https://www.cbar.az/currencies/";

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetCurrencyCoefficient(string code)
        {
            if (code == "azn") return 1;

            var url = $"{_currencyUrlBasePath}{DateTime.Now.ToString("dd.MM.yyyy")}.xml";

            var response = await _httpClient.GetStringAsync(url);

            XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
            ValCurs valCurs;

            using (StringReader reader = new StringReader(response))
            {
                valCurs = (ValCurs)serializer.Deserialize(reader);
            }

            var currencies = valCurs?.ValType.FirstOrDefault(x => x.Type == "Xarici valyutalar");

            var selectedCurrency = currencies?.Valute.FirstOrDefault(x => x.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));

            return (decimal)(selectedCurrency?.Value ?? 1);
        }

    }
}
