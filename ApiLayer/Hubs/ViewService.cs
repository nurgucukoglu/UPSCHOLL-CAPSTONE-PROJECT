using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace ApiLayer.Hubs
{
    public class ViewService
    {
        private readonly Context _context;
        private readonly IHubContext<ViewHub> _hubContext;

        public ViewService(Context context, IHubContext<ViewHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public IQueryable<MovieViews> GetList()
        {
            return _context.MovieViews.AsQueryable(); //izlenme verilerini querable olarak gönder.
        }

        public async Task SaveMovieViews(MovieViews movieViews)
        {
            await _context.MovieViews.AddAsync(movieViews);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveViewList", GetMovieViewChartList());
        }

        public List<MovieViewChart> GetMovieViewChartList()
        {
            List<MovieViewChart> movieViewCharts = new List<MovieViewChart>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select tarih,[1],[2],[3],[4],[5] from (select[Counrty],[Count],cast ([ViewDate]as date) as tarih From [MovieViews]) as movieViewT pivot (Sum(count) for [Counrty] in([1],[2],[3],[4],[5])) as ptable order by tarih asc";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();

                using(var reader= command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        MovieViewChart movieViewChart = new MovieViewChart() ;
                        movieViewChart.ViewDate = reader.GetDateTime(0).ToShortDateString();

                        Enumerable.Range(1, 7).ToList().ForEach(x =>
                        {
                            if (System.DBNull.Value.Equals(reader[x]))  //readerdan gelen değer boşsaa şunu ata...
                            {                                      //1.sn de ilk şehre yazınca charta yazarken diğerleri boş olduğu için hata vermesin diye.
                                movieViewChart.Counts.Add(0);
                            }
                            else
                            {
                                movieViewChart.Counts.Add(reader.GetInt32(x));
                            }
                        });
                        movieViewCharts.Add(movieViewChart);
                    }
                }
                _context.Database.CloseConnection();
                return movieViewCharts;
            }
        }
    }
}
