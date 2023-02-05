using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Abstract;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Commands;
using MediatR;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Queries;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    public class TasksController : Controller
    {
        private readonly IMediator _mediator;

        IMovieService _movieService;

        public TasksController(IMovieService movieService, IMediator mediator)
        {
            _movieService = movieService;
            _mediator = mediator;
        }

        public async Task<IActionResult> GetAllTasks()
        {
            var values = await _mediator.Send(new GetAllTaskQuery());
            return View(values);
        }

        [HttpGet] //ekleme  
        public async Task<IActionResult> AddTask()
        
        {
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

                List<string> movieTitle = new List<string>();

                var  newmoviesModel = movies.titles;
                
                foreach (var item in newmoviesModel)
                {
                    movieTitle.Add(item.jawSummary.title.ToString());
                    
                }
                ViewBag.MovieName = movieTitle;
                return View();

            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(CreateTaskCommand createTaskCommand)
        {
            await _mediator.Send(createTaskCommand);
            return View();
        }

        //silme
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _mediator.Send(new RemoveTaskCommand(id));
            return RedirectToAction("GetTasks");
        }


        //id.ye göre listeleme UPDATE GET
        [HttpGet]
        public async Task<IActionResult> UpdateTask(int id)
        {
            var values = await _mediator.Send(new GetTaskByIdQuery(id));
            return View(values);
        }


    }
}
