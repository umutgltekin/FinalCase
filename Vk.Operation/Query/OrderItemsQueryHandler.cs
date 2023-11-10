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
    public class OrderItemsQueryHandler :
        IRequestHandler<GetAllOrderItemsQuery, ApiResponse<List<OrderItemsResponse>>>,
        IRequestHandler<GetOrderItemsByIDQuery, ApiResponse<OrderItemsResponse>>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        public OrderItemsQueryHandler(IMapper map, VkContext context)
        {
            _context = context;
            _map = map;
        }
        public async Task<ApiResponse<List<OrderItemsResponse>>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<OrderItems>().Include(x => x.Product).Include(x => x.Order).ToList();
            var response = _map.Map<List<OrderItemsResponse>>(data);
            return new ApiResponse<List<OrderItemsResponse>>(response);
        }

        public async Task<ApiResponse<OrderItemsResponse>> Handle(GetOrderItemsByIDQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Set<OrderItems>().Include(x => x.Product).Include(x => x.Order).FirstOrDefault(x => x.Id == request.id);
            var response = _map.Map<OrderItemsResponse>(data);
            return new ApiResponse<OrderItemsResponse>(response);
        }
    }
}
