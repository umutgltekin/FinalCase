using AutoMapper;
using Azure;
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

namespace Vk.Operation.Query
{
    public class DealerQueryHandler :
        IRequestHandler<GetAllDealerQuery, ApiResponse<List<DealerResponse>>>,
        IRequestHandler<GetDealerByIDQuery, ApiResponse<DealerResponse>>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        public DealerQueryHandler(IMapper map, VkContext context) 
        {
            _context = context;
            _map = map;
        }
        public async Task<ApiResponse<List<DealerResponse>>> Handle(GetAllDealerQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<Dealer>().Include(x => x.Products).ToList();
            var response = _map.Map<List<DealerResponse>>(data);
            return new ApiResponse<List<DealerResponse>>(response);
        }

        public async Task<ApiResponse<DealerResponse>> Handle(GetDealerByIDQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<Dealer>().Include(x => x.Products).FirstOrDefault(x=> x.Id==request.id);
            var response = _map.Map<DealerResponse>(data);
            return new ApiResponse<DealerResponse>(response);
        }
    }
}
