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
    public class ProductCommandHandler:
        IRequestHandler<DeleteProductCommand, ApiResponse>,
        IRequestHandler<CreateProductCommand, ApiResponse<ProductResponse>>,
        IRequestHandler<UpdateProductCommand, ApiResponse>
    {
        private readonly IMapper _map;
        private readonly VkContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ProductCommandHandler(VkContext context, IMapper map, IUnitOfWork unitOfWork)
        {
            _context = context;
            _map = map;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var Product = _map.Map<Product>(request.model);
            var data = _context.Set<Product>().Add(Product);
            _context.SaveChanges();

            var response = _map.Map<ProductResponse>(data.Entity);
            return new ApiResponse<ProductResponse>(response);
        }

        public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<Product>().FirstOrDefault(x => x.Id == request.id);
            if (check != null)
            {
                check.IsActive = false;
                check.IsDeleted = true;
                _context.SaveChanges();
            }
            return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var check = _context.Set<Product>().FirstOrDefault(x => x.Id == request.id);
            check.ProductName = request.model.ProductName;
            _context.SaveChanges();
            return new ApiResponse();
        }
    }
}
