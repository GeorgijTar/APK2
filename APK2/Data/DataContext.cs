using APK2.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APK2.Data
{
   public class DataContext: DbContext
    {
        public DbSet<Status> Status { get; set; }
        public DbSet<TypeDoc> TypeDoc { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<DocumentsIndividual> DocumentsIndividual { get; set; }
        public DbSet<Individual> Individual { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Counterparty> Counterparty { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Invoce> Invoces { get; set; }
        public DbSet<RatesNDS> RatesNDs { get; set; }


        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Пример управления таблицами
            //modelBuilder.Entity<Status>().Property(s => s.Name)
            //    .HasMaxLength(100)
            //    .IsRequired();

            //modelBuilder.Entity<TypeDoc>().Property(s => s.NameType)
            //    .IsRequired()
            //    .HasMaxLength(150);
            //modelBuilder.Entity<TypeDoc>().Property(s => s.Status)
            //    .IsRequired();
            //modelBuilder.Entity<TypeDoc>().Property(s => s.TableType)
            //    .IsRequired()
            //    .HasMaxLength(150);

        }
    }
}
