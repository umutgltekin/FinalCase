using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vk.Base.Response;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Api.Controllers
{
    [Route("DealerController")]
    [ApiController]
    public class DealerController : Controller
    {
        private readonly IMediator _mediatR;

        public DealerController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<DealerResponse>> GetById(int id)
        {
            var operation = new GetDealerByIDQuery(id);
            var result= await _mediatR.Send(operation);
            return result;
        }
        [HttpPost]
        public async Task<ApiResponse<DealerResponse>> Post([FromBody] DealerRequest resuest)
        {
            var operation = new CreateDealerCommand(resuest);
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse<List<DealerResponse>>> GetAll()
        {
            var operation = new GetAllDealerQuery();
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateDealer(int id, [FromBody] DealerRequest resuest)
        {
            var operation = new UpdateDealerCommand(resuest,id);
            var result = await _mediatR.Send(operation);
            return result;
        }


    }
}
