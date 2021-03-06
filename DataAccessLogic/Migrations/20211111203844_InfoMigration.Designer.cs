// <auto-generated />
using System;
using DataAccessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLogic.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211111203844_InfoMigration")]
    partial class InfoMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LineItemsOrders", b =>
                {
                    b.Property<int>("LineItemsId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("LineItemsId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("LineItemsOrders");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customer_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("CustomerId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Models.LineItems", b =>
                {
                    b.Property<int>("LineItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("lineitem_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("StoreFrontId")
                        .HasColumnType("int")
                        .HasColumnName("storefront_id");

                    b.Property<int?>("StorefrontId")
                        .HasColumnType("int");

                    b.HasKey("LineItemsId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreFrontId");

                    b.HasIndex("StorefrontId");

                    b.ToTable("lineitem");
                });

            modelBuilder.Entity("Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("address");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int>("StoreFrontId")
                        .HasColumnType("int")
                        .HasColumnName("storefront_id");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("total_price");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StoreFrontId");

                    b.ToTable("order_");
                });

            modelBuilder.Entity("Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("brand");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(7,2)")
                        .HasColumnName("price");

                    b.HasKey("ProductId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Models.StoreFront", b =>
                {
                    b.Property<int>("StorefrontId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("storeFront_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("name");

                    b.HasKey("StorefrontId");

                    b.ToTable("storefront");
                });

            modelBuilder.Entity("LineItemsOrders", b =>
                {
                    b.HasOne("Models.LineItems", null)
                        .WithMany()
                        .HasForeignKey("LineItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Orders", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.LineItems", b =>
                {
                    b.HasOne("Models.Products", "Product")
                        .WithMany("LineItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__lineitem__produc__72C60C4A")
                        .IsRequired();

                    b.HasOne("Models.StoreFront", "StoreFront")
                        .WithMany("LineItems")
                        .HasForeignKey("StoreFrontId")
                        .HasConstraintName("FK__lineitem__storef__73BA3083")
                        .IsRequired();

                    b.HasOne("Models.StoreFront", null)
                        .WithMany("Products")
                        .HasForeignKey("StorefrontId");

                    b.Navigation("Product");

                    b.Navigation("StoreFront");
                });

            modelBuilder.Entity("Models.Orders", b =>
                {
                    b.HasOne("Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__order___customer__7A672E12")
                        .IsRequired();

                    b.HasOne("Models.StoreFront", "StoreFront")
                        .WithMany("Orders")
                        .HasForeignKey("StoreFrontId")
                        .HasConstraintName("FK__order___storefro__7B5B524B")
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("StoreFront");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Models.Products", b =>
                {
                    b.Navigation("LineItems");
                });

            modelBuilder.Entity("Models.StoreFront", b =>
                {
                    b.Navigation("LineItems");

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
