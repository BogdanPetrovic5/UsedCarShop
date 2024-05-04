﻿// <auto-generated />
using CarWebShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarWebShop.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240504161848_UpdatingCarTable")]
    partial class UpdatingCarTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarWebShop.Dto.CarDto", b =>
                {
                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<string>("EngineVolume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorsePower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Propulsion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("CarDto");
                });

            modelBuilder.Entity("CarWebShop.Dto.UserDto", b =>
                {
                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("UserDto_View", (string)null);
                });

            modelBuilder.Entity("CarWebShop.Models.Advertisement", b =>
                {
                    b.Property<int>("AdverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdverID"));

                    b.Property<string>("AdverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AdverID");

                    b.HasIndex("CarID")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Advertisement");
                });

            modelBuilder.Entity("CarWebShop.Models.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarID"));

                    b.Property<string>("CarBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineVolume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorsePower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.Property<string>("Propulsion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarWebShop.Models.Favorites", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("AdverID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "AdverID");

                    b.HasIndex("AdverID");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("CarWebShop.Models.ImagePaths", b =>
                {
                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AdverID")
                        .HasColumnType("int");

                    b.HasKey("ImagePath");

                    b.HasIndex("AdverID");

                    b.ToTable("ImagePaths");
                });

            modelBuilder.Entity("CarWebShop.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarWebShop.Models.Advertisement", b =>
                {
                    b.HasOne("CarWebShop.Models.Car", "Car")
                        .WithOne("Advertisement")
                        .HasForeignKey("CarWebShop.Models.Advertisement", "CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarWebShop.Models.User", "User")
                        .WithMany("Advertisements")
                        .HasForeignKey("UserID")
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarWebShop.Models.Car", b =>
                {
                    b.HasOne("CarWebShop.Models.User", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerID")
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarWebShop.Models.Favorites", b =>
                {
                    b.HasOne("CarWebShop.Models.Advertisement", "Advertisement")
                        .WithMany("FavoritedByUsers")
                        .HasForeignKey("AdverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarWebShop.Models.User", "User")
                        .WithMany("FavoriteAdvertisements")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarWebShop.Models.ImagePaths", b =>
                {
                    b.HasOne("CarWebShop.Models.Advertisement", "Advertisement")
                        .WithMany("imagePaths")
                        .HasForeignKey("AdverID")
                        .IsRequired();

                    b.Navigation("Advertisement");
                });

            modelBuilder.Entity("CarWebShop.Models.Advertisement", b =>
                {
                    b.Navigation("FavoritedByUsers");

                    b.Navigation("imagePaths");
                });

            modelBuilder.Entity("CarWebShop.Models.Car", b =>
                {
                    b.Navigation("Advertisement")
                        .IsRequired();
                });

            modelBuilder.Entity("CarWebShop.Models.User", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("Cars");

                    b.Navigation("FavoriteAdvertisements");
                });
#pragma warning restore 612, 618
        }
    }
}
