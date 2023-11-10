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
    public class OrderItemsCommandHandler:
        IRequestHandler<DeleteOrderItemsCommand, ApiResponse>,
        IRequestHandler<CreateOrderItemsCommand, ApiResponse<OrderItemsResponse>>,
        IRequestHandler<UpdateOrderItemsCommand, ApiResponse>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        public OrderItemsCommandHandler(VkContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        public async Task<ApiResponse<OrderItemsResponse>> Handle(CreateOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var OrderItems = _map.Map<OrderItems>(request);
            var data = _context.Set<OrderItems>().Add(OrderItems);
            _context.SaveChanges();

            var response = _map.Map<OrderItemsResponse>(data.Entity);
            return new ApiResponse<OrderItemsResponse>(response);
        }

        public async Task<ApiResponse> Handle(DeleteOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<OrderItems>().FirstOrDefault(x => x.Id == request.id);
            if (check != null)
            {
                check.IsActive = false;
                check.IsDeleted = true;
                _context.SaveChanges();
            }
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(UpdateOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<OrderItems>().FirstOrDefault(x => x.Id == request.id);
            check.TotalPrice = request.model.TotalPrice;
            _context.SaveChanges();
            return new ApiResponse();
        }
    }
}
