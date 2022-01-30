using RoomReservationProject.Data.Configurations;
using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RoomReservationProject.Data.Seeds;

namespace RoomReservationProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base
            (options)
        {

        }
        //Room
        public DbSet<Room> Rooms{ get; set; }
        public DbSet<RoomStatus> RoomStatuses{ get; set; }
        //Customer
        public DbSet<Customer> Customers { get; set; }
        //public DbQuery<CustomerVM> CustomerView { get; set; }

        //User
        public DbSet<User> Users { get; set; }
        //Reservation
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<PaymentHistory> PaymentHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new CustomerConfiguration());



          modelBuilder.ApplyConfiguration(new RoomStatusSeed(new int[] { 1, 2, 3,4 }));
        }

    }
}
