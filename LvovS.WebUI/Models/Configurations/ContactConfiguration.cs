using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LvovS.WebUI.Models.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
                
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            builder.Property(x => x.FirstName)

              .IsRequired()
              .HasMaxLength(50);
            builder.HasIndex(x => x.FirstName)
                .IsUnique();
            builder.HasIndex(x => x.LastName)
                 .IsUnique();
            builder.Property(x => x.LastName)
                
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.Email)
                .IsUnicode();
           
        }
    }
        //
    }