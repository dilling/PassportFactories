using System;
using Microsoft.EntityFrameworkCore;
using PassportCodeChallenge.Models;

namespace PassportCodeChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Factory> Factories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Factory>()
                .Property(e => e.Children)
                .HasConversion(
                    v => string.Join(",", v),
                    v => Array.ConvertAll(v.Split(",", StringSplitOptions.None), int.Parse)
                );
        }
    }
}