using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Base.Model;
using System.Security.Cryptography.X509Certificates;

namespace Vk.Data.Domain
{
    [Table("User")]
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string  Address { get; set; }
        public virtual List<Address>  Addresses{ get; set; }
        public virtual List<Order> Orders { get; set; }

    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.CreateUserId).IsRequired().UseIdentityColumn();
            builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.CrateDate).IsRequired();

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            
            builder.HasMany(x=>x.Addresses).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).IsRequired(true);
            builder.HasMany(x=>x.Orders).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).IsRequired(true);
        
        
        
        }
    }
}
