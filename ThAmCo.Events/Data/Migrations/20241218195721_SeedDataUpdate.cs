using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThAmCo.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Events",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDate",
                table: "Events",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "GuestId", "GuestEmail", "GuestName", "GuestPhone" },
                values: new object[,]
                {
                    { 6, "david.johnson@example.com", "David Johnson", "555-111-2222" },
                    { 7, "laura.martinez@example.com", "Laura Martinez", "555-333-4444" },
                    { 8, "james.anderson@example.com", "James Anderson", "555-666-7777" },
                    { 9, "patricia.taylor@example.com", "Patricia Taylor", "555-888-9999" },
                    { 10, "robert.lee@example.com", "Robert Lee", "555-000-1111" },
                    { 11, "linda.harris@example.com", "Linda Harris", "555-222-3333" },
                    { 12, "charles.clark@example.com", "Charles Clark", "555-444-5555" },
                    { 13, "barbara.lewis@example.com", "Barbara Lewis", "555-666-7777" },
                    { 14, "thomas.walker@example.com", "Thomas Walker", "555-888-9999" },
                    { 15, "nancy.hall@example.com", "Nancy Hall", "555-000-1111" }
                });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "GuestBookingId", "Attendance", "EventId", "GuestId" },
                values: new object[,]
                {
                    { 6, false, 2, 6 },
                    { 7, true, 2, 7 },
                    { 8, false, 2, 8 },
                    { 9, true, 2, 9 },
                    { 10, false, 2, 10 },
                    { 11, true, 2, 11 },
                    { 12, false, 2, 12 },
                    { 13, true, 2, 13 },
                    { 14, false, 2, 14 },
                    { 15, true, 2, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 15);

            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                table: "Events",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Events",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDate",
                table: "Events",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }
    }
}
