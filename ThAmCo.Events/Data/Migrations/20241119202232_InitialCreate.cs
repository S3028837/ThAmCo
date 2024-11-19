using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThAmCo.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReservationReference = table.Column<string>(type: "TEXT", nullable: true),
                    FoodBookingId = table.Column<int>(type: "INTEGER", nullable: true),
                    EventName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    EventType = table.Column<string>(type: "TEXT", nullable: true),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GuestPhone = table.Column<string>(type: "TEXT", nullable: true),
                    GuestEmail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StaffName = table.Column<string>(type: "TEXT", nullable: true),
                    StaffEmail = table.Column<string>(type: "TEXT", nullable: true),
                    FirstAidTrained = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "GuestBookings",
                columns: table => new
                {
                    GuestBookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    Attendance = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestBookings", x => x.GuestBookingId);
                    table.ForeignKey(
                        name: "FK_GuestBookings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestBookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffings",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffings", x => new { x.StaffId, x.EventId });
                    table.ForeignKey(
                        name: "FK_Staffings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffings_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "EventDate", "EventName", "EventType", "FoodBookingId", "ReservationReference" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year's Eve Gala", "Celebration", 1, "1" },
                    { 2, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate Retreat", "Business", 2, "2" },
                    { 3, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding Reception", "Celebration", 3, "3" },
                    { 4, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charity Fundraiser", "Fundraising", 4, "4" }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "GuestId", "GuestEmail", "GuestName", "GuestPhone" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", "123-456-7890" },
                    { 2, "jane.smith@example.com", "Jane Smith", "098-765-4321" },
                    { 3, "emily.davis@example.com", "Emily Davis", "555-123-4567" },
                    { 4, "michael.brown@example.com", "Michael Brown", "555-987-6543" },
                    { 5, "sarah.wilson@example.com", "Sarah Wilson", "555-555-5555" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "FirstAidTrained", "StaffEmail", "StaffName" },
                values: new object[,]
                {
                    { 1, true, "alice.johnson@example.com", "Alice Johnson" },
                    { 2, false, "bob.brown@example.com", "Bob Brown" },
                    { 3, true, "charlie.green@example.com", "Charlie Green" },
                    { 4, true, "diana.prince@example.com", "Diana Prince" },
                    { 5, false, "ethan.hunt@example.com", "Ethan Hunt" }
                });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "GuestBookingId", "Attendance", "EventId", "GuestId" },
                values: new object[,]
                {
                    { 1, false, 1, 1 },
                    { 2, true, 1, 2 },
                    { 3, true, 2, 3 },
                    { 4, false, 3, 4 },
                    { 5, true, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Staffings",
                columns: new[] { "EventId", "StaffId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_EventId",
                table: "GuestBookings",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_GuestId",
                table: "GuestBookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_EventId",
                table: "Staffings",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestBookings");

            migrationBuilder.DropTable(
                name: "Staffings");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
