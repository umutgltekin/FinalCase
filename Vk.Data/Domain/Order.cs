using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Model;

namespace Vk.Data.Domain
{
    [Table("Order")]
    public class Order : BaseModel
    {
        public string OrderName  { get; set; }
        public int UserId { get; set; }
        public int DealerId { get; set; }
        public int OrderNumber { get; set; }
        public virtual List<OrderItems> OrderItems { get; set; }

        public virtual User User { get; set; }
        public virtual Dealer Dealer { get; set; }

    }
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.CreateUserId).IsRequired().UseIdentityColumn();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.CrateDate).IsRequired();

            builder.Property(x => x.OrderName).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.DealerId).IsRequired();
            builder.Property(x => x.OrderNumber).IsRequired();

            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).IsRequired(true);
        }
    }
}
