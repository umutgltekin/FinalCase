using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vk.Base.Response;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Api.Controllers
{
    [Route("UserController")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediatR;

        public UserController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<UserResponse>> GetById(int id)
        {
            var operation = new GetUserByIDQuery(id);
            var result= await _mediatR.Send(operation);
            return result;
        }
        [HttpPost]
        public async Task<ApiResponse<UserResponse>> Post([FromBody] UserResuest resuest)
        {
            var operation = new CreateUserCommand(resuest);
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpGet]
        public async Task<ApiResponse<List<UserResponse>>> GetAll()
        {
            var operation = new GetAllUserQuery();
            var result = await _mediatR.Send(operation);
            return result;
        }
        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateUser(int id, [FromBody] UserResuest resuest)
        {
            var operation = new UpdateUserCommand(resuest,id);
            var result = await _mediatR.Send(operation);
            return result;
        }


    }
}
