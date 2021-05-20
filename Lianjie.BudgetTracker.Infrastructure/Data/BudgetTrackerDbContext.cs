using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lianjie.BudgetTracker.Infrastructure.Data
{
    public class BudgetTrackerDbContext : DbContext
    {

        // "base" is Dbcontext constructor, options, inject the value in the diff databases like a abstraction 
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Income> Incomes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Expenditure>(ConfigureExpenditure);
            modelBuilder.Entity<Income>(ConfigureIncome);

        }



        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.FullName).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(10);
            builder.Property(u => u.JoinedOn).HasDefaultValueSql("getdate()");
        }

        private void ConfigureExpenditure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditures");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.Property(e => e.Amount).HasColumnType("money");
            builder.Property(e => e.ExpDate).HasDefaultValueSql("getdate()");
        }


        private void ConfigureIncome(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Description).HasMaxLength(100);
            builder.Property(i => i.Remarks).HasMaxLength(500);
            builder.Property(i => i.Amount).HasColumnType("money");
            builder.Property(i => i.IncomeDate).HasDefaultValueSql("getdate()");
        }

    }
}
