﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Catering.Data;

#nullable disable

namespace ThAmCo.Catering.Data.Migrations
{
    [DbContext(typeof(CateringDbContext))]
    partial class CateringDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("ThAmCo.Catering.Data.FoodBooking", b =>
                {
                    b.Property<int>("FoodBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientReferenceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MenuId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("INTEGER");

                    b.HasKey("FoodBookingId");

                    b.HasIndex("MenuId");

                    b.ToTable("FoodBookings");

                    b.HasData(
                        new
                        {
                            FoodBookingId = 1,
                            ClientReferenceId = 1,
                            MenuId = 1,
                            NumberOfGuests = 4
                        },
                        new
                        {
                            FoodBookingId = 2,
                            ClientReferenceId = 2,
                            MenuId = 2,
                            NumberOfGuests = 2
                        },
                        new
                        {
                            FoodBookingId = 3,
                            ClientReferenceId = 3,
                            MenuId = 3,
                            NumberOfGuests = 3
                        },
                        new
                        {
                            FoodBookingId = 4,
                            ClientReferenceId = 4,
                            MenuId = 1,
                            NumberOfGuests = 5
                        },
                        new
                        {
                            FoodBookingId = 5,
                            ClientReferenceId = 5,
                            MenuId = 4,
                            NumberOfGuests = 6
                        },
                        new
                        {
                            FoodBookingId = 6,
                            ClientReferenceId = 6,
                            MenuId = 2,
                            NumberOfGuests = 1
                        });
                });

            modelBuilder.Entity("ThAmCo.Catering.Data.FoodItem", b =>
                {
                    b.Property<int>("FoodItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<float?>("UnitPrice")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.HasKey("FoodItemId");

                    b.ToTable("FoodItems");

                    b.HasData(
                        new
                        {
                            FoodItemId = 1,
                            Description = "Pizza",
                            UnitPrice = 8.99f
                        },
                        new
                        {
                            FoodItemId = 2,
                            Description = "Burger",
                            UnitPrice = 5.49f
                        },
                        new
                        {
                            FoodItemId = 3,
                            Description = "Pasta",
                            UnitPrice = 7.99f
                        },
                        new
                        {
                            FoodItemId = 4,
                            Description = "Salad",
                            UnitPrice = 4.99f
                        },
                        new
                        {
                            FoodItemId = 5,
                            Description = "Sushi",
                            UnitPrice = 12.99f
                        },
                        new
                        {
                            FoodItemId = 6,
                            Description = "Steak",
                            UnitPrice = 15.99f
                        },
                        new
                        {
                            FoodItemId = 7,
                            Description = "Tacos",
                            UnitPrice = 3.99f
                        },
                        new
                        {
                            FoodItemId = 8,
                            Description = "Ice Cream",
                            UnitPrice = 2.99f
                        });
                });

            modelBuilder.Entity("ThAmCo.Catering.Data.Menu", b =>
                {
                    b.Property<int>("MenuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("MenuID");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            MenuID = 1,
                            MenuName = "Breakfast Menu"
                        },
                        new
                        {
                            MenuID = 2,
                            MenuName = "Lunch Menu"
                        },
                        new
                        {
                            MenuID = 3,
                            MenuName = "Dinner Menu"
                        },
                        new
                        {
                            MenuID = 4,
                            MenuName = "Dessert Menu"
                        });
                });

            modelBuilder.Entity("ThAmCo.Catering.Data.MenuFoodItem", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoodItemID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MenuId", "FoodItemID");

                    b.HasIndex("FoodItemID");

                    b.ToTable("MenuFoodItems");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            FoodItemID = 1
                        },
                        new
                        {
                            MenuId = 1,
                            FoodItemID = 2
                        },
                        new
                        {
                            MenuId = 2,
                            FoodItemID = 3
                        },
                        new
                        {
                            MenuId = 2,
                            FoodItemID = 4
                        },
                        new
                        {
                            MenuId = 3,
                            FoodItemID = 5
                        },
                        new
                        {
                            MenuId = 3,
                            FoodItemID = 6
                        },
                        new
                        {
                            MenuId = 4,
                            FoodItemID = 7
                        },
                        new
                        {
                            MenuId = 4,
                            FoodItemID = 8
                        });
                });

            modelBuilder.Entity("ThAmCo.Catering.Data.FoodBooking", b =>
                {
                    b.HasOne("ThAmCo.Catering.Data.Menu", "Menu")
                        .WithMany("FoodBookings")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("ThAmCo.Catering.Data.MenuFoodItem", b =>
                {
                    b.HasOne("ThAmCo.Catering.Data.FoodItem", "FoodItem")
                        .WithMany("MenuFoodItems")
                        .HasForeignKey("FoodItemID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ThAmCo.Catering.Data.Menu", "Menu")
                        .WithMany("MenuFoodItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("ThAmCo.Catering.Data.FoodItem", b =>
                {
                    b.Navigation("MenuFoodItems");
                });

            modelBuilder.Entity("ThAmCo.Catering.Data.Menu", b =>
                {
                    b.Navigation("FoodBookings");

                    b.Navigation("MenuFoodItems");
                });
#pragma warning restore 612, 618
        }
    }
}