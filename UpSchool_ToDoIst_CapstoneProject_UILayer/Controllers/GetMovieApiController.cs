using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    public class GetMovieApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GetMovieApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44359/api/GetMovie"); //get url aldık çünkü get kullanıcaz.

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<MoviesModel>>(jsondata); //gelen json veriyi list şeklinde görüntülemek için deserialize ettik.
                return View(result);
            }
            else
            {
                ViewBag.responseMessage = "Bir hata oluştu";
                return View();
            }
            
        }
    }
}
