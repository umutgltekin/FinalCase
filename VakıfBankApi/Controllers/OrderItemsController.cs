using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vk.Base.Response;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Api.Controllers
{
    [Route("OrderItemsController")]
    [ApiController]
    public class OrderItemsController : Controller
    {
        private readonly IMediator _mediatR;

        public OrderItemsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<OrderItemsResponse>> GetById(int id)
        {
            var operation = new GetOrderItemsByIDQuery(id);
            var result= await _mediatR.Send(operation);
            return result;
        }
        [HttpPost]
        public async Task<ApiResponse<OrderItemsResponse>> Post([FromBody] OrderItemsRequest resuest)
        {
            var operation = new CreateOrderItemsCommand(resuest);
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse<List<OrderItemsResponse>>> GetAll()
        {
            var operation = new GetAllOrderItemsQuery();
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateOrderItems(int id, [FromBody] OrderItemsRequest resuest)
        {
            var operation = new UpdateOrderItemsCommand(resuest,id);
            var result = await _mediatR.Send(operation);
            return result;
        }


    }
}
