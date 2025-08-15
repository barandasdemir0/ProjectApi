using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RapidApi.Consume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {

            List<ApiMovieImdbViewModel> movies = new List<ApiMovieImdbViewModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies1.p.rapidapi.com/"),
                Headers =
                {
                    { "x-rapidapi-key", "94e4eaa144msha687f3ef56acd9dp1adad8jsn3d0b1a394640" },
                    { "x-rapidapi-host", "imdb-top-100-movies1.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                // JSON array → List<ApiMovieImdbViewModel>
                movies = JsonConvert.DeserializeObject<List<ApiMovieImdbViewModel>>(body);

                return View(movies);
            }

        }
    }
}


