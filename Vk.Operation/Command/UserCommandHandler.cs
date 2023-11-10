using AutoMapper;
using Azure.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Operation.Command
{
    public class UserCommandHandler :
        IRequestHandler<CreateUserCommand, ApiResponse<UserResponse>>,
        IRequestHandler<UpdateUserCommand, ApiResponse>,
        IRequestHandler<DeleteUserCommand, ApiResponse>
    {
        private readonly VkContext  _context;
        private readonly IMapper _map;
        public UserCommandHandler(VkContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<User>().FirstOrDefault(x => x.Id == request.id);
            if(check != null)
            {
                check.IsActive = false;
                check.IsDeleted = true;
                _context.SaveChanges();

                return new ApiResponse();
            }
            return new ApiResponse("record not fount");
        }

        public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        { 
            var entity=  await _context.Set<User>().FirstOrDefaultAsync(x => x.Id == request.id,cancellationToken);
            entity.FirstName=request.model.FirstName;
            entity.LastName=request.model.LastName;
            _context.SaveChanges();
            return new ApiResponse();
        }

        async Task<ApiResponse<UserResponse>> IRequestHandler<CreateUserCommand, ApiResponse<UserResponse>>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _map.Map<User>(request.model);

            var data = _context.Set<User>().Add(user);
            _context.SaveChanges();

            var response = _map.Map<UserResponse>(data.Entity);
            return new ApiResponse<UserResponse>(response);
        }
    }
}
