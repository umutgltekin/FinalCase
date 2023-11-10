using Serilog;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Repository;

namespace Vk.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VkContext _context;
        public UnitOfWork(VkContext context)
        {
            _context = context;
            UserRepository = new GenericRepository<User>(_context);
            AddressRepository = new GenericRepository<Address>(_context);
            DealerRepository = new GenericRepository<Dealer>(_context);
            OrderRepository = new GenericRepository<Order>(_context);
            ProductRepository = new GenericRepository<Product>(_context);
            OrderItemRepository = new GenericRepository<OrderItems>(_context);
        }
        public IGenericRepository<User> UserRepository { get; private set; }
        public IGenericRepository<Address> AddressRepository { get; private set; }
        public IGenericRepository<Dealer> DealerRepository { get; private set; }
        public IGenericRepository<Order> OrderRepository { get; private set; }
        public IGenericRepository<Product> ProductRepository { get; private set; }
        public IGenericRepository<OrderItems> OrderItemRepository { get; private set; }

        public void CompalteTransaction()
        {
           using(var transaction=_context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Log.Error("Compalte trsaction", ex);
                }
          

            }
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
