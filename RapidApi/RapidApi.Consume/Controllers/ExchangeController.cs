using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RapidApi.Consume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
          

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "94e4eaa144msha687f3ef56acd9dp1adad8jsn3d0b1a394640" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                var exchangeRates = root?.data?.exchange_rates?.ToList() ?? new List<ExchangeViewModel.Exchange_Rates>();
                return View(exchangeRates);

            }

        }
    }
}
