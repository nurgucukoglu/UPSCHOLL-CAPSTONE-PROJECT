using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_UILayer.Models;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public List<ExcelMovieModel> ExcelMovieList() //önce model üzerinden listeye erişmemiz lazım.
        {
            List<ExcelMovieModel> excelMovieModel = new List<ExcelMovieModel>();

            using (var context = new Context()) //customer entitye erişmemiz gerek çünkü onun üzerinden atamalarımızı yapıcaz.
            {
                excelMovieModel = context.Tasks.Select(x => new ExcelMovieModel //customerviewmodelse atama yapıcaz. select ile çekicez.
                {

                   MovieName=x.MovieName,
                   Status=x.Status,
                   WatchDate=x.Date

                }).ToList();

                return excelMovieModel;

            }

        }



        public IActionResult DynamicExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Movie List");//bir çalışma sayfası oluşturucaz.
                worksheet.Cell(1, 1).Value = "Movie Name";
                worksheet.Cell(1, 2).Value = "Watch Status";
                worksheet.Cell(1, 3).Value = "Date";
              


                int rowCount = 2; //count ile listeden
                foreach (var item in ExcelMovieList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.MovieName;
                    worksheet.Cell(rowCount, 2).Value = item.Status;
                    worksheet.Cell(rowCount, 3).Value = item.WatchDate;
               
                    rowCount++;
                }

                using (var stream = new MemoryStream())//stream:dosya işlemlerinde kullanılır. //BU SEFER YUKARIDAKİNDEN FARKLI YAPTIK.
                {
                    workbook.SaveAs(stream); //akışın içine workbboktan gelen değeri dahil ettik.
                    var content = stream.ToArray(); //direkt diziye çevirdik bu sefer 
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Movie_List.xlsx");
                }
            }

        }
    }
}
