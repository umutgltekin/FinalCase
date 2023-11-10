using AutoMapper;
using MediatR;
using System.Data.Entity;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Operation.Cqrs;
using Vk.Schema;

namespace Vk.Operation.Query
{
    public class AdressQueryHandler :
        IRequestHandler<GetAllAdressQuery, ApiResponse<List<AdressResponse>>>,
        IRequestHandler<GetAdressByIDQuery, ApiResponse<AdressResponse>>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        public AdressQueryHandler(IMapper map, VkContext context)
        {
            _context = context;
            _map = map;
        }
        public async Task<ApiResponse<List<AdressResponse>>> Handle(GetAllAdressQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<Address>().Include(x => x.User).ToList();
            var response = _map.Map<List<AdressResponse>>(data);
            return new ApiResponse<List<AdressResponse>>(response);
        }

        public async Task<ApiResponse<AdressResponse>> Handle(GetAdressByIDQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<Address>().Include(x => x.User).FirstOrDefault(x => x.Id == request.id);
            var response = _map.Map<AdressResponse>(data);
            return new ApiResponse<AdressResponse>(response);
        }
    }
}
