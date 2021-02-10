using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Models
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions options) : base(options)
        {
        }


        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Order_items> Order_items { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {/*
            modelBuilder.Entity<Order>()
                        .HasOne(e => e.Order_items)
                        .WithOne(o => o.Payment)
                        .*/
        }
    }

   
}
