using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ElectronicsStoreApi.DAL;

namespace ElectronicsStoreApi.Migrations
{
    [DbContext(typeof(StoreDataContext))]
    [Migration("20170322234341_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectronicsStoreApi.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CustomerAddress")
                        .IsRequired();

                    b.Property<string>("CustomerEmail")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ElectronicsStoreApi.Models.OrderRow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("OrderId")
                        .IsRequired();

                    b.Property<long?>("ProductId")
                        .IsRequired();

                    b.Property<int?>("Quantity")
                        .IsRequired();

                    b.Property<decimal?>("SingleProductPrice")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderRows");
                });

            modelBuilder.Entity("ElectronicsStoreApi.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal?>("Price")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ElectronicsStoreApi.Models.OrderRow", b =>
                {
                    b.HasOne("ElectronicsStoreApi.Models.Order", "Order")
                        .WithMany("Rows")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ElectronicsStoreApi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
