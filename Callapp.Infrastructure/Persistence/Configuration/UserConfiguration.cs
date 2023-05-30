using Callapp.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);
            builder.OwnsOne(x => x.UserProfile, x=>
            {
                x.ToTable("UserProfile");
                x.HasKey(x => x.EntityId);
            });
        }
    }
}
