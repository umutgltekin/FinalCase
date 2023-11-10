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
    public record CreateOrderItemsCommand(OrderItemsRequest model) : IRequest<ApiResponse<OrderItemsResponse>>;
    public record UpdateOrderItemsCommand(OrderItemsRequest model, int id) : IRequest<ApiResponse>;
    public record DeleteOrderItemsCommand(int id) : IRequest<ApiResponse>;

    public record GetAllOrderItemsQuery() : IRequest<ApiResponse<List<OrderItemsResponse>>>;
    public record GetOrderItemsByIDQuery(int id) : IRequest<ApiResponse<OrderItemsResponse>>;
}
