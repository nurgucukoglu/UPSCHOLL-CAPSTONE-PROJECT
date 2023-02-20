using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ApiLayer.Hubs
{
    public class ViewHub:Hub
    {
        private readonly ViewService _service;

        public ViewHub(ViewService service)
        {
            _service = service;
        }

        public async Task  GetViewList()
        {
            await Clients.All.SendAsync("ReceiveViewList", _service.GetMovieViewChartsList());
        }
    }
}
