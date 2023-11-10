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
    public class ProductQueryHandler :
        IRequestHandler<GetAllProductQuery, ApiResponse<List<ProductResponse>>>,
        IRequestHandler<GetProductByIDQuery, ApiResponse<ProductResponse>>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        public ProductQueryHandler(IMapper map, VkContext context)
        {
            _context = context;
            _map = map;
        }
        public async Task<ApiResponse<List<ProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<Product>().Include(x => x.Dealer).ToList();
            var response = _map.Map<List<ProductResponse>>(data);
            return new ApiResponse<List<ProductResponse>>(response);
        }

        public async Task<ApiResponse<ProductResponse>> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<Product>().Include(x => x.Dealer).FirstOrDefault(x => x.Id == request.id);
            var response = _map.Map<ProductResponse>(data);
            return new ApiResponse<ProductResponse>(response);
        }
    }
}
