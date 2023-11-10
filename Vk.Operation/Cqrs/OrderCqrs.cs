using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operation.Cqrs
{
    public record CreateOrderCommand(OrderRequest model) : IRequest<ApiResponse<OrderResponse>>;
    public record UpdateOrderCommand(OrderRequest model, int id) : IRequest<ApiResponse>;
    public record DeleteOrderCommand(int id) : IRequest<ApiResponse>;

    public record GetAllOrderQuery() : IRequest<ApiResponse<List<OrderResponse>>>;
    public record GetOrderByIDQuery(int id) : IRequest<ApiResponse<OrderResponse>>;
}
