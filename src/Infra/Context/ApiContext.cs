using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseInMemoryDatabase("teste");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }

    }
}