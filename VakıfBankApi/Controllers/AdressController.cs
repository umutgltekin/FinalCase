using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vk.Base.Response;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Api.Controllers
{
    [Route("AdressController")]
    [ApiController]
    public class AdressController : Controller
    {
        private readonly IMediator _mediatR;

        public AdressController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<AdressResponse>> GetById(int id)
        {
            var operation = new GetAdressByIDQuery(id);
            var result= await _mediatR.Send(operation);
            return result;
        }
        [HttpPost]
        public async Task<ApiResponse<AdressResponse>> Post([FromBody] AdressRequest resuest)
        {
            var operation = new CreateAdressCommand(resuest);
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse<List<AdressResponse>>> GetAll()
        {
            var operation = new GetAllAdressQuery();
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateAdress(int id, [FromBody] AdressRequest resuest)
        {
            var operation = new UpdateAdressCommand(resuest,id);
            var result = await _mediatR.Send(operation);
            return result;
        }


    }
}
