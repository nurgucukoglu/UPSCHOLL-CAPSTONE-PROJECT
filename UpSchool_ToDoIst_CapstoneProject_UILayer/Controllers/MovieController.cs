using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Abstract;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    [AllowAnonymous]
    public  class MovieController : Controller
    {
        IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task< IActionResult> Index()
        
        {
            //List<MoviesModel> movies= new List<MoviesModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://netflix54.p.rapidapi.com/search/?query=stranger&offset=0&limit_titles=50&limit_suggestions=20&lang=en"),
                Headers =
                {
                    { "X-RapidAPI-Key", "a3378a37b0msh5b71648c7f86cd8p163e36jsnf2a7310249f9" },
                    { "X-RapidAPI-Host", "netflix54.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var movies = JsonConvert.DeserializeObject<MoviesModel.Rootobject>(body);  //datayı getirdiğim için deserialize

                //_movieService.TInsert(movies);

                return View(movies.titles);

                
                
            }
            
        }

      
           
    }
 
}
