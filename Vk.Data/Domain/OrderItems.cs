using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Model;

namespace Vk.Data.Domain
{
    public class OrderItems : BaseModel
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
    public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.Property(x => x.CreateUserId).IsRequired().UseIdentityColumn();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.CrateDate).IsRequired();

            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired();

        }
    }
}
