using APBD_2Test_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_2Test_2.Context
{
    public class SchoolDBContext : DbContext
    {

        public SchoolDBContext()
        {

        }
        public SchoolDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s22814;Integrated Security=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfectioneryClientOrder>()
                .HasKey(cc => new { cc.IdClientOrder, cc.IdConfectionery });

            modelBuilder.Entity<ConfectioneryClientOrder>()
                .HasOne<ClientOrder>(cco => cco.ClientOrder)
                .WithMany(co => co.ConfectioneryClientOrders)
                .HasForeignKey(cco => cco.IdClientOrder);
            modelBuilder.Entity<ConfectioneryClientOrder>()
                .HasOne<Confectionery>(cco => cco.Confectionery)
                .WithMany(c => c.ConfectioneryClientOrders)
                .HasForeignKey(cco => cco.IdConfectionery);

            modelBuilder.Entity<Client>().HasData(
                new Client { IdClient = 1, FirstName = "Jan", LastName = "Kowalski" },
                new Client { IdClient = 2, FirstName = "Sebastian", LastName = "Nowak" },
                new Client { IdClient = 3, FirstName = "Jan", LastName = "Kowalski" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { IdEmployee = 1, FirstName = "Adam", LastName = "Buksa" },
                new Employee { IdEmployee = 2, FirstName = "Robert", LastName = "Lewandowski" },
                new Employee { IdEmployee = 3, FirstName = "Adam", LastName = "Zalewski" }
                );
            modelBuilder.Entity<Confectionery>().HasData(
                new Confectionery { IdConfectionery = 1, Name = "Confectionery1", PricePerOne = 10.10f }
                );
            modelBuilder.Entity<ClientOrder>().HasData(
                new ClientOrder { IdClientOrder = 1, OrderDate = DateTime.Now, IdClient=1,IdEmployee=1},
                new ClientOrder { IdClientOrder = 2, OrderDate = DateTime.Now, IdClient=1,IdEmployee=2},
                new ClientOrder { IdClientOrder = 3, OrderDate = DateTime.Now, IdClient=3,IdEmployee=2},
                new ClientOrder { IdClientOrder = 4, OrderDate = DateTime.Now, IdClient=1,IdEmployee=1}
                );
            modelBuilder.Entity<ConfectioneryClientOrder>().HasData(
                new ConfectioneryClientOrder { IdClientOrder = 1, IdConfectionery = 1, Amount = 10, Comments = "some comments" },
                new ConfectioneryClientOrder { IdClientOrder = 2, IdConfectionery = 1, Amount = 20, Comments = "some comments" },
                new ConfectioneryClientOrder { IdClientOrder = 3, IdConfectionery = 1, Amount = 5, Comments = "some comments" }
                );
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }
        public DbSet<ConfectioneryClientOrder> ConfectioneryClientOrders { get; set; }
    }
}
