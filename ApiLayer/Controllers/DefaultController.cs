using ApiLayer.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ViewService _viewService;

        public DefaultController(ViewService viewService)
        {
            _viewService = viewService;
        }


        [HttpPost]
        public async Task<IActionResult> SaveMovieViews(MovieViews movieViews)  //bu post işlemiyle postmanda elect verisini manuel olarak giricez.
        {
            await _viewService.SaveMovieViews(movieViews);
            //IQueryable<MovieViews> movieViewList = _viewService.GetList();
            return Ok(_viewService.GetMovieViewChartList());
        }

        [HttpGet]
        public IActionResult SendData()  
        {
            Random rnd = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x => //range aralık sağlar
            {
                foreach (Counrty item in Enum.GetValues(typeof(Counrty)))
                {
                    var newModelViews = new MovieViews
                    {
                        Counrty = item,
                        Count = rnd.Next(100, 1000),
                        ViewDate = DateTime.Now.AddDays(x) //x: range.in değerlerini alıcak
                    };
                    _viewService.SaveMovieViews(newModelViews).Wait();
                    System.Threading.Thread.Sleep(1000);  //bu işlemler 1 sn arayla gerçekleşecek.
                }
            });
            return Ok("İzlenme verileri veri tabanına kaydedildi");  //5 tane şehir var: 1.sn de 1.tarih için; istanbul da verileri kaydetti
                                                                      // ankara, izmir.. 2.tarih için de ist ankara, izmir.. bunu 10 kere tekrarlıcak. % şehir var her biri 1 sn. Toplam işlem 50 sn, db.de toplam 50 veri olmalı. 
        }
    }
}
