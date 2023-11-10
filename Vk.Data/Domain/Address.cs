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
    [Table("Address")]
    public class Address : BaseModel
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
    public class AdressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.CreateUserId).IsRequired().UseIdentityColumn();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.CrateDate).IsRequired();

            builder.Property(x => x.AdressLine1).HasMaxLength(128);
            builder.Property(x => x.AdressLine2).HasMaxLength(128);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Country).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PostalCode).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.User)
              .WithMany(u => u.Addresses)
              .HasForeignKey(x => x.UserId);
        }
    }
}
