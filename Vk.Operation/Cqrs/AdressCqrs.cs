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
    public record CreateAdressCommand(AdressRequest model) : IRequest<ApiResponse<AdressResponse>>;
    public record UpdateAdressCommand(AdressRequest model, int id) : IRequest<ApiResponse>;
    public record DeleteAdressCommand(int id) : IRequest<ApiResponse>;

    public record GetAllAdressQuery() : IRequest<ApiResponse<List<AdressResponse>>>;
    public record GetAdressByIDQuery(int id) : IRequest<ApiResponse<AdressResponse>>;
}
