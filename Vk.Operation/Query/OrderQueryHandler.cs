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
    public class OrderQueryHandler :
        IRequestHandler<GetAllOrderQuery, ApiResponse<List<OrderResponse>>>,
        IRequestHandler<GetOrderByIDQuery, ApiResponse<OrderResponse>>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        public OrderQueryHandler(IMapper map, VkContext context)
        {
            _context = context;
            _map = map;
        }
        public async Task<ApiResponse<List<OrderResponse>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<Order>().Include(x => x.Dealer).Include(x => x.User).ToList();
            var response = _map.Map<List<OrderResponse>>(data);
            return new ApiResponse<List<OrderResponse>>(response);
        }

        public async Task<ApiResponse<OrderResponse>> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<Order>().Include(x => x.Dealer).Include(x => x.User).FirstOrDefault(x => x.Id == request.id);
            var response = _map.Map<OrderResponse>(data);
            return new ApiResponse<OrderResponse>(response);
        }
    }
}
