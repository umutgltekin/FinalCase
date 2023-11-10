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
    public record CreateDealerCommand(DealerRequest model) : IRequest<ApiResponse<DealerResponse>>;
    public record UpdateDealerCommand(DealerRequest model, int id) : IRequest<ApiResponse>;
    public record DeleteDealerCommand(int id) : IRequest<ApiResponse>;

    public record GetAllDealerQuery() : IRequest<ApiResponse<List<DealerResponse>>>;
    public record GetDealerByIDQuery(int id) : IRequest<ApiResponse<DealerResponse>>;

}
