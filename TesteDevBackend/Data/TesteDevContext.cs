using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteDev.Models;

namespace TesteDev.Data
{
    public class TesteDevContext : DbContext
    {
        public TesteDevContext (DbContextOptions<TesteDevContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasQueryFilter(c => c.DataExcluido == null);
        }
    }
}
