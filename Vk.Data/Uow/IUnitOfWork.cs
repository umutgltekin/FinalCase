using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Data.Domain;
using Vk.Data.Repository;

namespace Vk.Data.Uow
{
    public interface IUnitOfWork
    {
        void Complete();
        void CompalteTransaction();
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Address> AddressRepository { get; }
        IGenericRepository<Dealer> DealerRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<OrderItems> OrderItemRepository { get; }


    }
}
