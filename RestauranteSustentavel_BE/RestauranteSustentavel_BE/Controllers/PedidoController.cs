using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSustentavel_BE.Models;
using RestauranteSustentavel_BE.Repository;
using RestauranteSustentavel_BE.Services;

namespace RestauranteSustentavel_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly PedidoService pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }


        [HttpGet]
        public List<Pedido> Get()
        {
            return pedidoService.Get();
        }
    }
}
