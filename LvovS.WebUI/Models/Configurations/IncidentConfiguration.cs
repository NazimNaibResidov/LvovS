using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LvovS.WebUI.Models.Configurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

        }
    }
        //
    }