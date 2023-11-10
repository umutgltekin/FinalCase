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
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Operation.Command
{
    public class DealerCommandHandler :
        IRequestHandler<DeleteDealerCommand, ApiResponse>,
        IRequestHandler<CreateDealerCommand, ApiResponse<DealerResponse>>,
        IRequestHandler<UpdateDealerCommand, ApiResponse>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        public DealerCommandHandler(VkContext context,IMapper map) { 
            _context = context;
            _map = map;
        }
        public async Task<ApiResponse<DealerResponse>> Handle(CreateDealerCommand request, CancellationToken cancellationToken)
        {
            var dealer = _map.Map<Dealer>(request.model);
            var data = _context.Set<Dealer>().Add(dealer);
            _context.SaveChanges();

            var response= _map.Map<DealerResponse>(data.Entity);
            return new ApiResponse<DealerResponse>(response);
        }

        public async Task<ApiResponse> Handle(DeleteDealerCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<Dealer>().FirstOrDefault(x => x.Id == request.id);
            if (check != null)
            {
                check.IsActive = false;
                check.IsDeleted = true;
                _context.SaveChanges();
            }
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(UpdateDealerCommand request, CancellationToken cancellationToken)
        {
            var check= _context.Set<Dealer>().FirstOrDefault(x =>x.Id == request.id);   
            check.FirstName=request.model.FirstName;
            check.LastName=request.model.LastName;
            check.Email=request.model.Email;
            _context.SaveChanges();
            return new ApiResponse();
        }
    }
}
