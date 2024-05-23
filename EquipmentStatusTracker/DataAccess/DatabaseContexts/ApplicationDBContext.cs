using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DatabaseContexts
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CommunicationDetail> CommunicationDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentShippingDetail> EquipmentShippingDetails { get; set; }
        public DbSet<EquipmentStatus> EquipmentStatuses { get; set; }
        public DbSet<GpsPosition> GpsPositions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=equipmentapp.db", b => b.MigrationsAssembly("DataAccess"));
        }

        //public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        //{
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Seed data
        //    modelBuilder.Entity<Address>().HasData(
        //        new Address { Id = 1, Street = "123 Main St", StreetNumber = "1", PostalCode = "12345", City = "Anytown", State = "Agder", Country = "Norway" },
        //        new Address { Id = 2, Street = "456 Elm St", StreetNumber = "2", PostalCode = "67890", City = "Othertown", State = "State", Country = "Australia" }
        //    );

        //    modelBuilder.Entity<Equipment>().HasData(
        //        new Equipment { EquipmentId = 1, Name = "Excavator", Description = "Large construction equipment" },
        //        new Equipment { EquipmentId = 2, Name = "Bulldozer", Description = "Heavy equipment for pushing earth" }
        //    );

        //    modelBuilder.Entity<CommunicationDetail>().HasData(
        //        new CommunicationDetail { Id = 1, Email = "john.doe@example.com", PhoneNumber = "123-456-7890", AddressId = 1 },
        //        new CommunicationDetail { Id = 2, Email = "jane.smith@example.com", PhoneNumber = "987-654-3210", AddressId = 2 }
        //    );

        //    modelBuilder.Entity<Customer>().HasData(
        //        new Customer { Id = 1, CustomerName = "John Doe", CommunicationDetailId = 1 },
        //        new Customer { Id = 2, CustomerName = "Jane Smith", CommunicationDetailId = 2 }
        //    );

        //    modelBuilder.Entity<EquipmentShippingDetail>().HasData(
        //        new EquipmentShippingDetail { Id = 1, EquipmentId = 1, Quantity = 1, SendingAddressId = 1, DestinationAddressId = 2, AdditionalNotes = "Handle with care" }
        //    );

        //    modelBuilder.Entity<GpsPosition>().HasData(
        //        new GpsPosition { Id = 1, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.UtcNow },
        //        new GpsPosition { Id = 2, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.UtcNow }
        //    );

        //    modelBuilder.Entity<EquipmentStatus>().HasData(
        //        new EquipmentStatus { Id = 1, EquipmentShippingDetailId = 1, CustomerId = 1 }
        //    );
        //}
    }
}
