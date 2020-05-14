﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReverseEngineeringDb.DataContext;

namespace ReverseEngineeringDb.Migrations
{
    [DbContext(typeof(InsuredItemsDbContext))]
    partial class InsuredItemsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReverseEngineeringDb.DataContext.Address", b =>
                {
                    b.Property<int>("CompanyKey")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CompanyKey");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ReverseEngineeringDb.DataContext.Company", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Key");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ReverseEngineeringDb.DataContext.CompanyCompanyType", b =>
                {
                    b.Property<int>("CompanyKey")
                        .HasColumnType("int");

                    b.Property<int>("CompanyTypeKey")
                        .HasColumnType("int");

                    b.HasKey("CompanyKey", "CompanyTypeKey");

                    b.HasIndex("CompanyTypeKey");

                    b.ToTable("CompanyCompanyType");
                });

            modelBuilder.Entity("ReverseEngineeringDb.DataContext.CompanyType", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Key");

                    b.ToTable("CompanyTypes");
                });

            modelBuilder.Entity("ReverseEngineeringDb.DataContext.Address", b =>
                {
                    b.HasOne("ReverseEngineeringDb.DataContext.Company", null)
                        .WithOne("Address")
                        .HasForeignKey("ReverseEngineeringDb.DataContext.Address", "CompanyKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReverseEngineeringDb.DataContext.CompanyCompanyType", b =>
                {
                    b.HasOne("ReverseEngineeringDb.DataContext.Company", "Company")
                        .WithMany("CompanyCompanyTypes")
                        .HasForeignKey("CompanyKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReverseEngineeringDb.DataContext.CompanyType", "CompanyType")
                        .WithMany("CompanyCompanyTypes")
                        .HasForeignKey("CompanyTypeKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
