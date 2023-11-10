using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Operation.Command
{
    public class AdressCommandHandler:
        IRequestHandler<DeleteAdressCommand, ApiResponse>,
        IRequestHandler<CreateAdressCommand, ApiResponse<AdressResponse>>,
        IRequestHandler<UpdateAdressCommand, ApiResponse>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public AdressCommandHandler(VkContext context, IMapper map, IUnitOfWork unitOfWork)
        {
            _context = context;
            _map = map;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<AdressResponse>> Handle(CreateAdressCommand request, CancellationToken cancellationToken)
        {
            var Adress = _map.Map<Address>(request.model);
            User user = new User();
            
            var data = _context.Set<Address>().Add(Adress);
            _context.SaveChanges();

            var response = _map.Map<AdressResponse>(data.Entity);
            return new ApiResponse<AdressResponse>(response);
        }

        public async Task<ApiResponse> Handle(DeleteAdressCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<Address>().FirstOrDefault(x => x.Id == request.id);
            if (check != null)
            {
                check.IsActive = false;
                check.IsDeleted = true;
                _context.SaveChanges();
            }
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(UpdateAdressCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<Address>().FirstOrDefault(x => x.Id == request.id);
            check.AdressLine1 = request.model.AdressLine1;
            _context.SaveChanges();
            return new ApiResponse();
        }
    }
}
