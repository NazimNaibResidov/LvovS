using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LvovS.WebUI.Models.Configurations
{
    public class AccountContactConfiguration : IEntityTypeConfiguration<AccountContact>
    {
        public void Configure(EntityTypeBuilder<AccountContact> builder)
        {
            builder.HasKey(x => new {x.AccountId,x.ContactId });
        }
    }
}
