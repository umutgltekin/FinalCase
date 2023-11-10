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
    public record CreateProductCommand(ProductRequest model) : IRequest<ApiResponse<ProductResponse>>;
    public record UpdateProductCommand(ProductRequest model, int id) : IRequest<ApiResponse>;
    public record DeleteProductCommand(int id) : IRequest<ApiResponse>;

    public record GetAllProductQuery() : IRequest<ApiResponse<List<ProductResponse>>>;
    public record GetProductByIDQuery(int id) : IRequest<ApiResponse<ProductResponse>>;
}
