using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operation.Cqrs
{

        public record CreateUserCommand (UserResuest model):IRequest<ApiResponse<UserResponse>>;
        public record UpdateUserCommand (UserResuest model, int id):IRequest<ApiResponse>;
        public record DeleteUserCommand (int id):IRequest<ApiResponse>;

        public record GetAllUserQuery() : IRequest<ApiResponse<List<UserResponse>>>;
        public record GetUserByIDQuery(int id) : IRequest<ApiResponse<UserResponse>>;
    
}
