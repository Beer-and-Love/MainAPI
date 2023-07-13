using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infra.Mappings;

namespace Infra.Context
{
    public class ApiContext:DbContext
    {
        public ApiContext()
        {}

        public ApiContext(DbContextOptions<ApiContext>options) : base(options)
        {}

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Localization> Localization { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BH2K3U2\SQLEXPRESS;Initial Catalog=BeerLove;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }

    }
}