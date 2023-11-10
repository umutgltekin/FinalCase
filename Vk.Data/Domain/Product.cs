using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Model;

namespace Vk.Data.Domain
{
    [Table("Product")]
    public class Product : BaseModel
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }
        public int  Stok { get; set; }
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
        public List<OrderItems> OrderItems { get; set; }

    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.CreateUserId).IsRequired().UseIdentityColumn();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.CrateDate).IsRequired();

            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ProductDescription).HasMaxLength(50);
            builder.Property(x => x.Stok).IsRequired();
            builder.Property(x => x.DealerId).IsRequired();

            builder.HasMany(x => x.OrderItems).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).IsRequired(true);
        }
    }
}
