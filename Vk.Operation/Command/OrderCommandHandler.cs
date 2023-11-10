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
    public class OrderCommandHandler:
        IRequestHandler<DeleteOrderCommand, ApiResponse>,
        IRequestHandler<CreateOrderCommand, ApiResponse<OrderResponse>>,
        IRequestHandler<UpdateOrderCommand, ApiResponse>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public OrderCommandHandler(VkContext context, IMapper map, IUnitOfWork unitOfWork)
        {
            _context = context;
            _map = map;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<OrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var Order = _map.Map<Order>(request.model);
            var data = _context.Set<Order>().Add(Order);
            _context.SaveChanges();

            var response = _map.Map<OrderResponse>(data.Entity);
            return new ApiResponse<OrderResponse>(response);
        }

        public async Task<ApiResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<Order>().FirstOrDefault(x => x.Id == request.id);
            if (check != null)
            {
                check.IsActive = false;
                check.IsDeleted = true;
                _context.SaveChanges();
            }
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<Order>().FirstOrDefault(x => x.Id == request.id);
            check.OrderName = request.model.OrderName;
            _context.SaveChanges();
            return new ApiResponse();
        }
    }
}
