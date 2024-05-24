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
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
               new Address { Id = 1, Street = "123 Main St", StreetNumber = "11", PostalCode = "12345", City = "Kristiansand", State = "Agder", Country = "Norway" },
               new Address { Id = 2, Street = "456 Elm St", StreetNumber = "23", PostalCode = "67890", City = "Sydney", State = "Sydney", Country = "Australia" },
               new Address { Id = 3, Street = "643 Main St", StreetNumber = "1", PostalCode = "3453", City = "Oslo", State = "Oslo", Country = "Norway" },
               new Address { Id = 4, Street = "4 Elm St", StreetNumber = "3", PostalCode = "6450", City = "Boston", State = "Massachusetts", Country = "USA" },
               new Address { Id = 5, Street = "789 Maple Ave", StreetNumber = "5", PostalCode = "67812", City = "Melbourne", State = "Victoria", Country = "Australia" },
               new Address { Id = 6, Street = "101 Oak St", StreetNumber = "14", PostalCode = "90210", City = "Beverly Hills", State = "California", Country = "USA" },
               new Address { Id = 7, Street = "202 Pine St", StreetNumber = "7", PostalCode = "80301", City = "Boulder", State = "Colorado", Country = "USA" },
               new Address { Id = 8, Street = "303 Cedar St", StreetNumber = "8", PostalCode = "10001", City = "New York", State = "New York", Country = "USA" },
               new Address { Id = 9, Street = "404 Birch St", StreetNumber = "9", PostalCode = "20001", City = "Washington", State = "District of Columbia", Country = "USA" },
               new Address { Id = 10, Street = "505 Spruce St", StreetNumber = "10", PostalCode = "94102", City = "San Francisco", State = "California", Country = "USA" },
               new Address { Id = 11, Street = "606 Walnut St", StreetNumber = "11", PostalCode = "60601", City = "Chicago", State = "Illinois", Country = "USA" },
               new Address { Id = 12, Street = "707 Chestnut St", StreetNumber = "12", PostalCode = "75201", City = "Dallas", State = "Texas", Country = "USA" },
               new Address { Id = 13, Street = "808 Aspen St", StreetNumber = "13", PostalCode = "98101", City = "Seattle", State = "Washington", Country = "USA" },
               new Address { Id = 14, Street = "909 Poplar St", StreetNumber = "14", PostalCode = "30301", City = "Atlanta", State = "Georgia", Country = "USA" },
               new Address { Id = 15, Street = "1010 Redwood St", StreetNumber = "15", PostalCode = "90001", City = "Los Angeles", State = "California", Country = "USA" },
               new Address { Id = 16, Street = "1111 Palm St", StreetNumber = "16", PostalCode = "77001", City = "Houston", State = "Texas", Country = "USA" },
               new Address { Id = 17, Street = "1212 Cedar Ave", StreetNumber = "17", PostalCode = "55401", City = "Minneapolis", State = "Minnesota", Country = "USA" },
               new Address { Id = 18, Street = "1313 Ash St", StreetNumber = "18", PostalCode = "73301", City = "Austin", State = "Texas", Country = "USA" },
               new Address { Id = 19, Street = "1414 Elm Dr", StreetNumber = "19", PostalCode = "85001", City = "Phoenix", State = "Arizona", Country = "USA" },
               new Address { Id = 20, Street = "1515 Maple Ln", StreetNumber = "20", PostalCode = "48201", City = "Detroit", State = "Michigan", Country = "USA" }
                );
            modelBuilder.Entity<CommunicationDetail>().HasData(
                    new CommunicationDetail { Id = 1, Email = "john.doe@example.com", PhoneNumber = "123-456-7890", AddressId = 1 },
                    new CommunicationDetail { Id = 2, Email = "jane.smith@example.com", PhoneNumber = "987-654-3210", AddressId = 2 },
                    new CommunicationDetail { Id = 3, Email = "john.wick@example.com", PhoneNumber = "823-456-7894", AddressId = 3 },
                    new CommunicationDetail { Id = 4, Email = "john.snow@example.com", PhoneNumber = "287-654-3213", AddressId = 4 },
                    new CommunicationDetail { Id = 5, Email = "alice.johnson@example.com", PhoneNumber = "123-789-4561", AddressId = 5 },
                    new CommunicationDetail { Id = 6, Email = "bob.brown@example.com", PhoneNumber = "321-654-9872", AddressId = 6 },
                    new CommunicationDetail { Id = 7, Email = "charlie.davis@example.com", PhoneNumber = "456-123-7893", AddressId = 7 },
                    new CommunicationDetail { Id = 8, Email = "diana.evans@example.com", PhoneNumber = "654-987-3214", AddressId = 8 },
                    new CommunicationDetail { Id = 9, Email = "ethan.harris@example.com", PhoneNumber = "789-456-1235", AddressId = 9 },
                    new CommunicationDetail { Id = 10, Email = "fiona.clark@example.com", PhoneNumber = "987-321-6546", AddressId = 10 },
                    new CommunicationDetail { Id = 11, Email = "george.hill@example.com", PhoneNumber = "123-654-9877", AddressId = 11 },
                    new CommunicationDetail { Id = 12, Email = "hannah.lewis@example.com", PhoneNumber = "321-987-6548", AddressId = 12 },
                    new CommunicationDetail { Id = 13, Email = "ian.martinez@example.com", PhoneNumber = "456-789-1239", AddressId = 13 },
                    new CommunicationDetail { Id = 14, Email = "jackie.taylor@example.com", PhoneNumber = "654-321-9870", AddressId = 14 },
                    new CommunicationDetail { Id = 15, Email = "karen.wilson@example.com", PhoneNumber = "789-123-4561", AddressId = 15 },
                    new CommunicationDetail { Id = 16, Email = "liam.king@example.com", PhoneNumber = "987-654-3212", AddressId = 16 },
                    new CommunicationDetail { Id = 17, Email = "mia.scott@example.com", PhoneNumber = "123-456-7893", AddressId = 17 },
                    new CommunicationDetail { Id = 18, Email = "nathan.walker@example.com", PhoneNumber = "321-654-9874", AddressId = 18 },
                    new CommunicationDetail { Id = 19, Email = "olivia.adams@example.com", PhoneNumber = "456-789-1235", AddressId = 19 },
                    new CommunicationDetail { Id = 20, Email = "paul.baker@example.com", PhoneNumber = "654-987-3216", AddressId = 20 }
                );
            modelBuilder.Entity<Customer>().HasData(
                    new Customer { Id = 1, CustomerName = "John Doe", CommunicationDetailId = 1 },
                    new Customer { Id = 2, CustomerName = "Jane Smith", CommunicationDetailId = 2 },
                    new Customer { Id = 3, CustomerName = "John Wick", CommunicationDetailId = 3 },
                    new Customer { Id = 4, CustomerName = "John Snow", CommunicationDetailId = 4 },
                    new Customer { Id = 5, CustomerName = "Alice Johnson", CommunicationDetailId = 5 },
                    new Customer { Id = 6, CustomerName = "Bob Brown", CommunicationDetailId = 6 },
                    new Customer { Id = 7, CustomerName = "Charlie Davis", CommunicationDetailId = 7 },
                    new Customer { Id = 8, CustomerName = "Diana Evans", CommunicationDetailId = 8 },
                    new Customer { Id = 9, CustomerName = "Ethan Harris", CommunicationDetailId = 9 },
                    new Customer { Id = 10, CustomerName = "Fiona Clark", CommunicationDetailId = 10 },
                    new Customer { Id = 11, CustomerName = "George Hill", CommunicationDetailId = 11 },
                    new Customer { Id = 12, CustomerName = "Hannah Lewis", CommunicationDetailId = 12 },
                    new Customer { Id = 13, CustomerName = "Ian Martinez", CommunicationDetailId = 13 },
                    new Customer { Id = 14, CustomerName = "Jackie Taylor", CommunicationDetailId = 14 },
                    new Customer { Id = 15, CustomerName = "Karen Wilson", CommunicationDetailId = 15 },
                    new Customer { Id = 16, CustomerName = "Liam King", CommunicationDetailId = 16 },
                    new Customer { Id = 17, CustomerName = "Mia Scott", CommunicationDetailId = 17 },
                    new Customer { Id = 18, CustomerName = "Nathan Walker", CommunicationDetailId = 18 },
                    new Customer { Id = 19, CustomerName = "Olivia Adams", CommunicationDetailId = 19 },
                    new Customer { Id = 20, CustomerName = "Paul Baker", CommunicationDetailId = 20 }
                );
            modelBuilder.Entity<Equipment>().HasData(
                   new Equipment { Id = 1, Name = "Excavator", Description = "Large construction equipment" },
                   new Equipment { Id = 2, Name = "Bulldozer", Description = "Heavy equipment for pushing earth" },
                   new Equipment { Id = 3, Name = "Crane", Description = "Equipment used to lift and move materials" },
                   new Equipment { Id = 4, Name = "Dump Truck", Description = "Truck used for transporting loose materials" },
                   new Equipment { Id = 5, Name = "Loader", Description = "Machine used for moving and loading materials" },
                   new Equipment { Id = 6, Name = "Backhoe", Description = "Excavating and trenching equipment" },
                   new Equipment { Id = 7, Name = "Grader", Description = "Equipment used to create a flat surface" },
                   new Equipment { Id = 8, Name = "Forklift", Description = "Vehicle used for lifting and moving materials" },
                   new Equipment { Id = 9, Name = "Pile Driver", Description = "Equipment used to drive piles into the soil" },
                   new Equipment { Id = 10, Name = "Paver", Description = "Equipment used to lay asphalt on roads" },
                   new Equipment { Id = 11, Name = "Compactor", Description = "Machine used to reduce the size of waste material" },
                   new Equipment { Id = 12, Name = "Skid Steer Loader", Description = "Small rigid-frame, engine-powered machine" },
                   new Equipment { Id = 13, Name = "Drill Rig", Description = "Equipment used to create holes in the earth" },
                   new Equipment { Id = 14, Name = "Trencher", Description = "Equipment used to dig trenches" },
                   new Equipment { Id = 15, Name = "Dragline Excavator", Description = "Large excavator with a bucket" },
                   new Equipment { Id = 16, Name = "Concrete Mixer", Description = "Equipment used to mix concrete" },
                   new Equipment { Id = 17, Name = "Concrete Pump", Description = "Equipment used for transferring liquid concrete" },
                   new Equipment { Id = 18, Name = "Tower Crane", Description = "Crane used in the construction of tall buildings" },
                   new Equipment { Id = 19, Name = "Cement Truck", Description = "Truck used for transporting concrete" },
                   new Equipment { Id = 20, Name = "Asphalt Paver", Description = "Equipment used to lay asphalt on roads" },
                   new Equipment { Id = 21, Name = "Cold Planer", Description = "Machine used to remove asphalt or concrete" },
                   new Equipment { Id = 22, Name = "Scraper", Description = "Equipment used for earthmoving" },
                   new Equipment { Id = 23, Name = "Telehandler", Description = "Equipment used to lift materials" },
                   new Equipment { Id = 24, Name = "Roller", Description = "Equipment used to compact soil" },
                   new Equipment { Id = 25, Name = "Compactor", Description = "Machine used to compress materials" },
                   new Equipment { Id = 26, Name = "Boom Lift", Description = "Equipment used to provide temporary access" },
                   new Equipment { Id = 27, Name = "Scissor Lift", Description = "Lift used to provide access to high places" },
                   new Equipment { Id = 28, Name = "Hydraulic Hammer", Description = "Tool used for demolition" },
                   new Equipment { Id = 29, Name = "Pile Boring Machine", Description = "Machine used to create boreholes" },
                   new Equipment { Id = 30, Name = "Tunnel Boring Machine", Description = "Machine used to excavate tunnels" },
                   new Equipment { Id = 31, Name = "Motor Grader", Description = "Equipment used to create a flat surface" },
                   new Equipment { Id = 32, Name = "Skidder", Description = "Vehicle used for pulling logs" },
                   new Equipment { Id = 33, Name = "Harvester", Description = "Machine used for harvesting crops" },
                   new Equipment { Id = 34, Name = "Forwarder", Description = "Vehicle used for carrying logs" }
                );
                modelBuilder.Entity<EquipmentShippingDetail>().HasData(
                   new EquipmentShippingDetail { Id = 1, EquipmentId = 1, Quantity = 2, SendingAddressId = 1, DestinationAddressId = 2, AdditionalNotes = "Handle with care" },
                   new EquipmentShippingDetail { Id = 2, EquipmentId = 2, Quantity = 3, SendingAddressId = 2, DestinationAddressId = 3, AdditionalNotes = "Deliver during business hours" },
                   new EquipmentShippingDetail { Id = 3, EquipmentId = 3, Quantity = 1, SendingAddressId = 3, DestinationAddressId = 4, AdditionalNotes = "Fragile equipment" },
                   new EquipmentShippingDetail { Id = 4, EquipmentId = 4, Quantity = 5, SendingAddressId = 4, DestinationAddressId = 5, AdditionalNotes = "Ensure safety protocols" },
                   new EquipmentShippingDetail { Id = 5, EquipmentId = 5, Quantity = 4, SendingAddressId = 5, DestinationAddressId = 6, AdditionalNotes = "Check for damage upon arrival" },
                   new EquipmentShippingDetail { Id = 6, EquipmentId = 6, Quantity = 2, SendingAddressId = 6, DestinationAddressId = 7, AdditionalNotes = "Keep dry" },
                   new EquipmentShippingDetail { Id = 7, EquipmentId = 7, Quantity = 6, SendingAddressId = 7, DestinationAddressId = 8, AdditionalNotes = "Heavy load" },
                   new EquipmentShippingDetail { Id = 8, EquipmentId = 8, Quantity = 3, SendingAddressId = 8, DestinationAddressId = 9, AdditionalNotes = "Ensure proper handling" },
                   new EquipmentShippingDetail { Id = 9, EquipmentId = 9, Quantity = 7, SendingAddressId = 9, DestinationAddressId = 10, AdditionalNotes = "High value item" },
                   new EquipmentShippingDetail { Id = 10, EquipmentId = 10, Quantity = 2, SendingAddressId = 10, DestinationAddressId = 1, AdditionalNotes = "Secure packaging required" }
                    );
                modelBuilder.Entity<EquipmentStatus>().HasData(
                    new EquipmentStatus { Id = 1, EquipmentShippingDetailId = 1, CustomerId = 1 },
                    new EquipmentStatus { Id = 2, EquipmentShippingDetailId = 2, CustomerId = 2 },
                    new EquipmentStatus { Id = 3, EquipmentShippingDetailId = 3, CustomerId = 3 },
                    new EquipmentStatus { Id = 4, EquipmentShippingDetailId = 4, CustomerId = 4 },
                    new EquipmentStatus { Id = 5, EquipmentShippingDetailId = 5, CustomerId = 5 },
                    new EquipmentStatus { Id = 6, EquipmentShippingDetailId = 6, CustomerId = 6 },
                    new EquipmentStatus { Id = 7, EquipmentShippingDetailId = 7, CustomerId = 7 },
                    new EquipmentStatus { Id = 8, EquipmentShippingDetailId = 8, CustomerId = 8 },
                    new EquipmentStatus { Id = 9, EquipmentShippingDetailId = 9, CustomerId = 9 },
                    new EquipmentStatus { Id = 10, EquipmentShippingDetailId = 10, CustomerId = 10 }
                );
                modelBuilder.Entity<GpsPosition>().HasData(
                    new GpsPosition { Id = 1, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.UtcNow,EquipmentStatusId = 1 },
                    new GpsPosition { Id = 2, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 3, Latitude = 51.5074, Longitude = -0.1278, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 4, Latitude = 48.8566, Longitude = 2.3522, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 5, Latitude = 37.7749, Longitude = -122.4194, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 6, Latitude = 35.6895, Longitude = 139.6917, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 7, Latitude = -33.8688, Longitude = 151.2093, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 8, Latitude = 41.8781, Longitude = -87.6298, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 9, Latitude = 55.7558, Longitude = 37.6176, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 10, Latitude = -22.9068, Longitude = -43.1729, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 11, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 12, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 13, Latitude = 51.5074, Longitude = -0.1278, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 14, Latitude = 48.8566, Longitude = 2.3522, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 15, Latitude = 37.7749, Longitude = -122.4194, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 16, Latitude = 35.6895, Longitude = 139.6917, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 17, Latitude = -33.8688, Longitude = 151.2093, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 18, Latitude = 41.8781, Longitude = -87.6298, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 19, Latitude = 55.7558, Longitude = 37.6176, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 20, Latitude = -22.9068, Longitude = -43.1729, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 21, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 22, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 23, Latitude = 51.5074, Longitude = -0.1278, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 24, Latitude = 48.8566, Longitude = 2.3522, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 25, Latitude = 37.7749, Longitude = -122.4194, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 26, Latitude = 35.6895, Longitude = 139.6917, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 27, Latitude = -33.8688, Longitude = 151.2093, Timestamp = DateTime.UtcNow, EquipmentStatusId = 3 },
                    new GpsPosition { Id = 28, Latitude = 41.8781, Longitude = -87.6298, Timestamp = DateTime.UtcNow, EquipmentStatusId = 7 },
                    new GpsPosition { Id = 29, Latitude = 55.7558, Longitude = 37.6176, Timestamp = DateTime.UtcNow, EquipmentStatusId = 8 },
                    new GpsPosition { Id = 30, Latitude = -22.9068, Longitude = -43.1729, Timestamp = DateTime.UtcNow, EquipmentStatusId = 9 },
                    new GpsPosition { Id = 31, Latitude = 40.7128, Longitude = -74.0060, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 32, Latitude = 34.0522, Longitude = -118.2437, Timestamp = DateTime.UtcNow, EquipmentStatusId = 1 },
                    new GpsPosition { Id = 33, Latitude = 51.5074, Longitude = -0.1278, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 34, Latitude = 48.8566, Longitude = 2.3522, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 35, Latitude = 37.7749, Longitude = -122.4194, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 36, Latitude = 35.6895, Longitude = 139.6917, Timestamp = DateTime.UtcNow, EquipmentStatusId = 2 },
                    new GpsPosition { Id = 37, Latitude = -33.8688, Longitude = 151.2093, Timestamp = DateTime.UtcNow, EquipmentStatusId = 3 },
                    new GpsPosition { Id = 38, Latitude = 41.8781, Longitude = -87.6298, Timestamp = DateTime.UtcNow, EquipmentStatusId = 7 },
                    new GpsPosition { Id = 39, Latitude = 55.7558, Longitude = 37.6176, Timestamp = DateTime.UtcNow, EquipmentStatusId = 8 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
