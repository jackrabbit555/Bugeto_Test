﻿// <auto-generated />
using System;
using Bugeto_Test.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bugeto_Test.Persistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231218221251_addIsRemoved")]
    partial class addIsRemoved
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bugeto_Test.Domain.Entities.Users.Role", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Name = "Admin"
                        },
                        new
                        {
                            ID = 2L,
                            Name = "Oprator"
                        },
                        new
                        {
                            ID = 3L,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("Bugeto_Test.Domain.Entities.Users.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullNamee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Passaword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bugeto_Test.Domain.Entities.Users.UserInRole", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInRoles");
                });

            modelBuilder.Entity("Bugeto_Test.Domain.Entities.Users.UserInRole", b =>
                {
                    b.HasOne("Bugeto_Test.Domain.Entities.Users.Role", "Role")
                        .WithMany("UserInRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugeto_Test.Domain.Entities.Users.User", "User")
                        .WithMany("UserInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bugeto_Test.Domain.Entities.Users.Role", b =>
                {
                    b.Navigation("UserInRoles");
                });

            modelBuilder.Entity("Bugeto_Test.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("UserInRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
