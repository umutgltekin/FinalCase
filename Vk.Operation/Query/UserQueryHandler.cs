using AutoMapper;
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
using Vk.Data.Uow;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Operation.Query
{
    public class UserQueryHandler :
        IRequestHandler<GetAllUserQuery, ApiResponse<List<UserResponse>>>,
        IRequestHandler<GetUserByIDQuery, ApiResponse<UserResponse>>
    {
        private readonly VkContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserQueryHandler(VkContext context, IMapper mapper, IUnitOfWork unitOfWork)
        { 
            _mapper = mapper;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<UserResponse>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            List<User> list= _unitOfWork.UserRepository.GetAll("Addresses");
            var check = _context.Set<User>().Include(x => x.Addresses).Include(x => x.Orders).FirstOrDefault(x => x.Id == request.id);
            var response = _mapper.Map<UserResponse>(check);
            return new ApiResponse<UserResponse>(response);
        }

        public async Task<ApiResponse<List<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            List<User> list = _context.Set<User>().Include(x => x.Addresses).ToList();
            var response = _mapper.Map<List<UserResponse>>(list);
            return new ApiResponse<List<UserResponse>>(response);
        }
    }
}
