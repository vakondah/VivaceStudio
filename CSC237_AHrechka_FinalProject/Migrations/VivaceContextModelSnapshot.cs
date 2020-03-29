﻿// <auto-generated />
using System;
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSC237_AHrechka_FinalProject.Migrations
{
    [DbContext(typeof(VivaceContext))]
    partial class VivaceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountID = 1,
                            AccountEmail = "ahrechka@gmail.com",
                            Password = "123"
                        },
                        new
                        {
                            AccountID = 2,
                            AccountEmail = "stacym@gmail.com",
                            Password = "123"
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ImageID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            ImageID = 1,
                            ImageTitle = "crow.png",
                            UserID = 2
                        },
                        new
                        {
                            ImageID = 2,
                            ImageTitle = "",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.Instrument", b =>
                {
                    b.Property<int>("InstrumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstrumentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentID");

                    b.ToTable("Instruments");

                    b.HasData(
                        new
                        {
                            InstrumentID = 1,
                            InstrumentName = "Guitar"
                        },
                        new
                        {
                            InstrumentID = 2,
                            InstrumentName = "Piano"
                        },
                        new
                        {
                            InstrumentID = 3,
                            InstrumentName = "Violin"
                        },
                        new
                        {
                            InstrumentID = 4,
                            InstrumentName = "Chello"
                        },
                        new
                        {
                            InstrumentID = 5,
                            InstrumentName = "Saxophone"
                        },
                        new
                        {
                            InstrumentID = 6,
                            InstrumentName = "Triangle"
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.School", b =>
                {
                    b.Property<int>("SchoolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolID");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            SchoolID = 1,
                            SchoolName = "Rock Academy"
                        },
                        new
                        {
                            SchoolID = 2,
                            SchoolName = "Harmony School of Music"
                        },
                        new
                        {
                            SchoolID = 3,
                            SchoolName = "Centennial Piano School"
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherID = 1,
                            FirstName = "Andrew",
                            LastName = "Rusinn",
                            Phone = "720 666-4567"
                        },
                        new
                        {
                            TeacherID = 2,
                            FirstName = "Maria",
                            LastName = "Ortega",
                            Phone = "720 122-0809"
                        },
                        new
                        {
                            TeacherID = 3,
                            FirstName = "Lorena",
                            LastName = "Kirkland",
                            Phone = "720 898-3839"
                        },
                        new
                        {
                            TeacherID = 4,
                            FirstName = "Olga",
                            LastName = "Kostenko",
                            Phone = "303 920 1764"
                        },
                        new
                        {
                            TeacherID = 5,
                            FirstName = "John",
                            LastName = "Stivens",
                            Phone = "720 009-1890"
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstrumentID")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MyClasses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("AccountID");

                    b.HasIndex("InstrumentID");

                    b.HasIndex("SchoolID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            AccountID = 1,
                            Address = "9999 E Orange St, Aurora, CO, 80011",
                            Bio = "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.",
                            DateOfBirth = new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ahrechka@mail.com",
                            FirstName = "Aliaksandra",
                            InstrumentID = 1,
                            LastName = "Hrechka",
                            MyClasses = "Guitar, Choir",
                            Phone = "970-777-7777",
                            SchoolID = 2,
                            StudentNumber = 1010,
                            TeacherID = 1
                        },
                        new
                        {
                            UserID = 2,
                            AccountID = 2,
                            Address = "367 S Limone St, Denver, CO, 80235",
                            Bio = "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.",
                            DateOfBirth = new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "smiller16@mail.com",
                            FirstName = "Stacy",
                            InstrumentID = 2,
                            LastName = "Miller",
                            MyClasses = "Piano, Choir",
                            Phone = "720-303-6367",
                            SchoolID = 3,
                            StudentNumber = 1011,
                            TeacherID = 3
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.Image", b =>
                {
                    b.HasOne("CSC237_AHrechka_FinalProject.Models.User", "User")
                        .WithOne("Image")
                        .HasForeignKey("CSC237_AHrechka_FinalProject.Models.Image", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.User", b =>
                {
                    b.HasOne("CSC237_AHrechka_FinalProject.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSC237_AHrechka_FinalProject.Models.Instrument", "Instrument")
                        .WithMany()
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSC237_AHrechka_FinalProject.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSC237_AHrechka_FinalProject.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
