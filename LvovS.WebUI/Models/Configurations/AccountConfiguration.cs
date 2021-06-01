using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LvovS.WebUI.Models.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.Property(x => x.Email)
                .IsUnicode();
            builder.Property(x => x.UserName)
                .IsUnicode();
            builder.Property(x => x.Name)
                .HasMaxLength(50);
           

            
        }
    }
}