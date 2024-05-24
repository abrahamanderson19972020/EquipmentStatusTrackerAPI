using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GpsPositions_EquipmentStatuses_EquipmentStatusId",
                table: "GpsPositions");

            migrationBuilder.RenameColumn(
                name: "EquipmentId",
                table: "Equipments",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentStatusId",
                table: "GpsPositions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "EquipmentShippingDetails",
                type: "TEXT",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "State", "Street", "StreetNumber" },
                values: new object[,]
                {
                    { 1, "Kristiansand", "Norway", "12345", "Agder", "123 Main St", "11" },
                    { 2, "Sydney", "Australia", "67890", "Sydney", "456 Elm St", "23" },
                    { 3, "Oslo", "Norway", "3453", "Oslo", "643 Main St", "1" },
                    { 4, "Boston", "USA", "6450", "Massachusetts", "4 Elm St", "3" },
                    { 5, "Melbourne", "Australia", "67812", "Victoria", "789 Maple Ave", "5" },
                    { 6, "Beverly Hills", "USA", "90210", "California", "101 Oak St", "14" },
                    { 7, "Boulder", "USA", "80301", "Colorado", "202 Pine St", "7" },
                    { 8, "New York", "USA", "10001", "New York", "303 Cedar St", "8" },
                    { 9, "Washington", "USA", "20001", "District of Columbia", "404 Birch St", "9" },
                    { 10, "San Francisco", "USA", "94102", "California", "505 Spruce St", "10" },
                    { 11, "Chicago", "USA", "60601", "Illinois", "606 Walnut St", "11" },
                    { 12, "Dallas", "USA", "75201", "Texas", "707 Chestnut St", "12" },
                    { 13, "Seattle", "USA", "98101", "Washington", "808 Aspen St", "13" },
                    { 14, "Atlanta", "USA", "30301", "Georgia", "909 Poplar St", "14" },
                    { 15, "Los Angeles", "USA", "90001", "California", "1010 Redwood St", "15" },
                    { 16, "Houston", "USA", "77001", "Texas", "1111 Palm St", "16" },
                    { 17, "Minneapolis", "USA", "55401", "Minnesota", "1212 Cedar Ave", "17" },
                    { 18, "Austin", "USA", "73301", "Texas", "1313 Ash St", "18" },
                    { 19, "Phoenix", "USA", "85001", "Arizona", "1414 Elm Dr", "19" },
                    { 20, "Detroit", "USA", "48201", "Michigan", "1515 Maple Ln", "20" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Large construction equipment", "Excavator" },
                    { 2, "Heavy equipment for pushing earth", "Bulldozer" },
                    { 3, "Equipment used to lift and move materials", "Crane" },
                    { 4, "Truck used for transporting loose materials", "Dump Truck" },
                    { 5, "Machine used for moving and loading materials", "Loader" },
                    { 6, "Excavating and trenching equipment", "Backhoe" },
                    { 7, "Equipment used to create a flat surface", "Grader" },
                    { 8, "Vehicle used for lifting and moving materials", "Forklift" },
                    { 9, "Equipment used to drive piles into the soil", "Pile Driver" },
                    { 10, "Equipment used to lay asphalt on roads", "Paver" },
                    { 11, "Machine used to reduce the size of waste material", "Compactor" },
                    { 12, "Small rigid-frame, engine-powered machine", "Skid Steer Loader" },
                    { 13, "Equipment used to create holes in the earth", "Drill Rig" },
                    { 14, "Equipment used to dig trenches", "Trencher" },
                    { 15, "Large excavator with a bucket", "Dragline Excavator" },
                    { 16, "Equipment used to mix concrete", "Concrete Mixer" },
                    { 17, "Equipment used for transferring liquid concrete", "Concrete Pump" },
                    { 18, "Crane used in the construction of tall buildings", "Tower Crane" },
                    { 19, "Truck used for transporting concrete", "Cement Truck" },
                    { 20, "Equipment used to lay asphalt on roads", "Asphalt Paver" },
                    { 21, "Machine used to remove asphalt or concrete", "Cold Planer" },
                    { 22, "Equipment used for earthmoving", "Scraper" },
                    { 23, "Equipment used to lift materials", "Telehandler" },
                    { 24, "Equipment used to compact soil", "Roller" },
                    { 25, "Machine used to compress materials", "Compactor" },
                    { 26, "Equipment used to provide temporary access", "Boom Lift" },
                    { 27, "Lift used to provide access to high places", "Scissor Lift" },
                    { 28, "Tool used for demolition", "Hydraulic Hammer" },
                    { 29, "Machine used to create boreholes", "Pile Boring Machine" },
                    { 30, "Machine used to excavate tunnels", "Tunnel Boring Machine" },
                    { 31, "Equipment used to create a flat surface", "Motor Grader" },
                    { 32, "Vehicle used for pulling logs", "Skidder" },
                    { 33, "Machine used for harvesting crops", "Harvester" },
                    { 34, "Vehicle used for carrying logs", "Forwarder" }
                });

            migrationBuilder.InsertData(
                table: "CommunicationDetails",
                columns: new[] { "Id", "AddressId", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "123-456-7890" },
                    { 2, 2, "jane.smith@example.com", "987-654-3210" },
                    { 3, 3, "john.wick@example.com", "823-456-7894" },
                    { 4, 4, "john.snow@example.com", "287-654-3213" },
                    { 5, 5, "alice.johnson@example.com", "123-789-4561" },
                    { 6, 6, "bob.brown@example.com", "321-654-9872" },
                    { 7, 7, "charlie.davis@example.com", "456-123-7893" },
                    { 8, 8, "diana.evans@example.com", "654-987-3214" },
                    { 9, 9, "ethan.harris@example.com", "789-456-1235" },
                    { 10, 10, "fiona.clark@example.com", "987-321-6546" },
                    { 11, 11, "george.hill@example.com", "123-654-9877" },
                    { 12, 12, "hannah.lewis@example.com", "321-987-6548" },
                    { 13, 13, "ian.martinez@example.com", "456-789-1239" },
                    { 14, 14, "jackie.taylor@example.com", "654-321-9870" },
                    { 15, 15, "karen.wilson@example.com", "789-123-4561" },
                    { 16, 16, "liam.king@example.com", "987-654-3212" },
                    { 17, 17, "mia.scott@example.com", "123-456-7893" },
                    { 18, 18, "nathan.walker@example.com", "321-654-9874" },
                    { 19, 19, "olivia.adams@example.com", "456-789-1235" },
                    { 20, 20, "paul.baker@example.com", "654-987-3216" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentShippingDetails",
                columns: new[] { "Id", "AdditionalNotes", "DestinationAddressId", "EquipmentId", "Quantity", "SendingAddressId" },
                values: new object[,]
                {
                    { 1, "Handle with care", 2, 1, 2, 1 },
                    { 2, "Deliver during business hours", 3, 2, 3, 2 },
                    { 3, "Fragile equipment", 4, 3, 1, 3 },
                    { 4, "Ensure safety protocols", 5, 4, 5, 4 },
                    { 5, "Check for damage upon arrival", 6, 5, 4, 5 },
                    { 6, "Keep dry", 7, 6, 2, 6 },
                    { 7, "Heavy load", 8, 7, 6, 7 },
                    { 8, "Ensure proper handling", 9, 8, 3, 8 },
                    { 9, "High value item", 10, 9, 7, 9 },
                    { 10, "Secure packaging required", 1, 10, 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CommunicationDetailId", "CustomerName" },
                values: new object[,]
                {
                    { 1, 1, "John Doe" },
                    { 2, 2, "Jane Smith" },
                    { 3, 3, "John Wick" },
                    { 4, 4, "John Snow" },
                    { 5, 5, "Alice Johnson" },
                    { 6, 6, "Bob Brown" },
                    { 7, 7, "Charlie Davis" },
                    { 8, 8, "Diana Evans" },
                    { 9, 9, "Ethan Harris" },
                    { 10, 10, "Fiona Clark" },
                    { 11, 11, "George Hill" },
                    { 12, 12, "Hannah Lewis" },
                    { 13, 13, "Ian Martinez" },
                    { 14, 14, "Jackie Taylor" },
                    { 15, 15, "Karen Wilson" },
                    { 16, 16, "Liam King" },
                    { 17, 17, "Mia Scott" },
                    { 18, 18, "Nathan Walker" },
                    { 19, 19, "Olivia Adams" },
                    { 20, 20, "Paul Baker" }
                });

            migrationBuilder.InsertData(
                table: "EquipmentStatuses",
                columns: new[] { "Id", "CustomerId", "EquipmentShippingDetailId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "GpsPositions",
                columns: new[] { "Id", "EquipmentStatusId", "Latitude", "Longitude", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1, 40.712800000000001, -74.006, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8607) },
                    { 2, 1, 34.052199999999999, -118.2437, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8609) },
                    { 3, 1, 51.507399999999997, -0.1278, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8609) },
                    { 4, 1, 48.8566, 2.3521999999999998, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8610) },
                    { 5, 1, 37.774900000000002, -122.4194, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8611) },
                    { 6, 1, 35.689500000000002, 139.6917, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8612) },
                    { 7, 1, -33.8688, 151.20930000000001, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8612) },
                    { 8, 1, 41.878100000000003, -87.629800000000003, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8613) },
                    { 9, 1, 55.755800000000001, 37.617600000000003, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8614) },
                    { 10, 1, -22.9068, -43.172899999999998, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8614) },
                    { 11, 1, 40.712800000000001, -74.006, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8615) },
                    { 12, 1, 34.052199999999999, -118.2437, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8616) },
                    { 13, 2, 51.507399999999997, -0.1278, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8616) },
                    { 14, 2, 48.8566, 2.3521999999999998, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8617) },
                    { 15, 2, 37.774900000000002, -122.4194, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8618) },
                    { 16, 2, 35.689500000000002, 139.6917, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8618) },
                    { 17, 2, -33.8688, 151.20930000000001, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8619) },
                    { 18, 2, 41.878100000000003, -87.629800000000003, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8619) },
                    { 19, 2, 55.755800000000001, 37.617600000000003, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8620) },
                    { 20, 2, -22.9068, -43.172899999999998, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8621) },
                    { 21, 1, 40.712800000000001, -74.006, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8621) },
                    { 22, 1, 34.052199999999999, -118.2437, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8622) },
                    { 23, 2, 51.507399999999997, -0.1278, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8623) },
                    { 24, 2, 48.8566, 2.3521999999999998, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8623) },
                    { 25, 2, 37.774900000000002, -122.4194, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8624) },
                    { 26, 2, 35.689500000000002, 139.6917, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8625) },
                    { 27, 3, -33.8688, 151.20930000000001, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8625) },
                    { 28, 7, 41.878100000000003, -87.629800000000003, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8626) },
                    { 29, 8, 55.755800000000001, 37.617600000000003, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8627) },
                    { 30, 9, -22.9068, -43.172899999999998, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8627) },
                    { 31, 1, 40.712800000000001, -74.006, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8628) },
                    { 32, 1, 34.052199999999999, -118.2437, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8629) },
                    { 33, 2, 51.507399999999997, -0.1278, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8629) },
                    { 34, 2, 48.8566, 2.3521999999999998, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8630) },
                    { 35, 2, 37.774900000000002, -122.4194, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8631) },
                    { 36, 2, 35.689500000000002, 139.6917, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8631) },
                    { 37, 3, -33.8688, 151.20930000000001, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8632) },
                    { 38, 7, 41.878100000000003, -87.629800000000003, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8633) },
                    { 39, 8, 55.755800000000001, 37.617600000000003, new DateTime(2024, 5, 24, 18, 47, 44, 820, DateTimeKind.Utc).AddTicks(8633) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GpsPositions_EquipmentStatuses_EquipmentStatusId",
                table: "GpsPositions",
                column: "EquipmentStatusId",
                principalTable: "EquipmentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GpsPositions_EquipmentStatuses_EquipmentStatusId",
                table: "GpsPositions");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "GpsPositions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EquipmentStatuses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EquipmentShippingDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CommunicationDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Equipments",
                newName: "EquipmentId");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentStatusId",
                table: "GpsPositions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "EquipmentShippingDetails",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GpsPositions_EquipmentStatuses_EquipmentStatusId",
                table: "GpsPositions",
                column: "EquipmentStatusId",
                principalTable: "EquipmentStatuses",
                principalColumn: "Id");
        }
    }
}
