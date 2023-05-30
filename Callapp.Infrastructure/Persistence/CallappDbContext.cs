using Callapp.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callapp.Infrastructure.Persistence
{
    public class CallappDbContext : DbContext
    {
        public CallappDbContext(DbContextOptions<CallappDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
