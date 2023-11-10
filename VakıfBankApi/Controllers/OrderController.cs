using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vk.Base.Response;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Api.Controllers
{
    [Route("OrderController")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediatR;

        public OrderController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<OrderResponse>> GetById(int id)
        {
            var operation = new GetOrderByIDQuery(id);
            var result= await _mediatR.Send(operation);
            return result;
        }
        [HttpPost]
        public async Task<ApiResponse<OrderResponse>> Post([FromBody] OrderRequest resuest)
        {
            var operation = new CreateOrderCommand(resuest);
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse<List<OrderResponse>>> GetAll()
        {
            var operation = new GetAllOrderQuery();
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateOrder(int id, [FromBody] OrderRequest resuest)
        {
            var operation = new UpdateOrderCommand(resuest,id);
            var result = await _mediatR.Send(operation);
            return result;
        }


    }
}
