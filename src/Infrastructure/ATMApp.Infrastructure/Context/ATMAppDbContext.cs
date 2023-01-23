using ATMApp.Domain.Entities;
using ATMApp.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Infrastructure.Context
{
    public class ATMAppDbContext : DbContext
    {
        public ATMAppDbContext(DbContextOptions<ATMAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig())
                .ApplyConfiguration(new UserProcessConfig());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProcess> UserProcesses { get; set; }
    }
}
