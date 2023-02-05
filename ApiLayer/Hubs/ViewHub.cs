using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ApiLayer.Hubs
{
    public class ViewHub:Hub
    {
        private readonly ViewService _viewService;

        public ViewHub(ViewService viewService)
        {
            _viewService = viewService;
        }

        public async Task  GetViewList()
        {
            await Clients.All.SendAsync("ReceiveViewList", _viewService.GetMovieViewChartList());
        }
    }
}
