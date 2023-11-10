using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vk.Base.Response;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Api.Controllers
{
    [Route("ProductController")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediatR;

        public ProductController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<ProductResponse>> GetById(int id)
        {
            var operation = new GetProductByIDQuery(id);
            var result= await _mediatR.Send(operation);
            return result;
        }
        [HttpPost]
        public async Task<ApiResponse<ProductResponse>> Post([FromBody] ProductRequest resuest)
        {
            var operation = new CreateProductCommand(resuest);
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse<List<ProductResponse>>> GetAll()
        {
            var operation = new GetAllProductQuery();
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateProduct(int id, [FromBody] ProductRequest resuest)
        {
            var operation = new UpdateProductCommand(resuest,id);
            var result = await _mediatR.Send(operation);
            return result;
        }


    }
}
