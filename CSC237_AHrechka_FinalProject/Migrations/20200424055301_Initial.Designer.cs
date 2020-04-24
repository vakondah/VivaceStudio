﻿// <auto-generated />
using System;
using CSC237_AHrechka_FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSC237_AHrechka_FinalProject.Migrations
{
    [DbContext(typeof(VivaceContext))]
    [Migration("20200424055301_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ImageID");

                    b.HasIndex("UserID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.Instrument", b =>
                {
                    b.Property<string>("InstrumentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InstrumentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentID");

                    b.ToTable("Instruments");

                    b.HasData(
                        new
                        {
                            InstrumentID = "gtr",
                            InstrumentName = "Guitar"
                        },
                        new
                        {
                            InstrumentID = "pno",
                            InstrumentName = "Piano"
                        },
                        new
                        {
                            InstrumentID = "vln",
                            InstrumentName = "Violin"
                        },
                        new
                        {
                            InstrumentID = "cel",
                            InstrumentName = "Cello"
                        },
                        new
                        {
                            InstrumentID = "sax",
                            InstrumentName = "Saxophone"
                        },
                        new
                        {
                            InstrumentID = "trg",
                            InstrumentName = "Triangle"
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.PracticeLog", b =>
                {
                    b.Property<int>("PracticeLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InProgress")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PracticeEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PracticeStartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PracticeLogID");

                    b.HasIndex("UserID");

                    b.ToTable("PracticeLog");
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.School", b =>
                {
                    b.Property<string>("SchoolID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolID");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            SchoolID = "RA",
                            SchoolName = "Rock Academy"
                        },
                        new
                        {
                            SchoolID = "HSM",
                            SchoolName = "Harmony School of Music"
                        },
                        new
                        {
                            SchoolID = "CPS",
                            SchoolName = "Centennial Piano School"
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.Teacher", b =>
                {
                    b.Property<string>("TeacherID")
                        .HasColumnType("nvarchar(450)");

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
                            TeacherID = "100",
                            FirstName = "Andrew",
                            LastName = "Rusinn",
                            Phone = "720 666-4567"
                        },
                        new
                        {
                            TeacherID = "200",
                            FirstName = "Maria",
                            LastName = "Ortega",
                            Phone = "720 122-0809"
                        },
                        new
                        {
                            TeacherID = "300",
                            FirstName = "Lorena",
                            LastName = "Kirkland",
                            Phone = "720 898-3839"
                        },
                        new
                        {
                            TeacherID = "400",
                            FirstName = "Olga",
                            LastName = "Kostenko",
                            Phone = "303 920 1764"
                        },
                        new
                        {
                            TeacherID = "500",
                            FirstName = "John",
                            LastName = "Stivens",
                            Phone = "720 009-1890"
                        });
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstrumentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MyClasses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SchoolID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<string>("TeacherID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("InstrumentID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("SchoolID");

                    b.HasIndex("TeacherID");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "3d5b12fa-ba1d-4af4-904e-d10fd0c72e14",
                            AccessFailedCount = 0,
                            Address = "9999 E Orange St, Aurora, CO, 80011",
                            Bio = "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.",
                            ConcurrencyStamp = "f9055171-8000-4aaf-ba5a-0b14064b7cb7",
                            DateOfBirth = new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Aliaksandra",
                            InstrumentID = "gtr",
                            LastName = "Hrechka",
                            LockoutEnabled = false,
                            MyClasses = "Guitar, Choir",
                            Phone = "970-777-7777",
                            PhoneNumberConfirmed = false,
                            SchoolID = "RA",
                            SecurityStamp = "ba559306-f248-42de-a227-dbba6ac51c1c",
                            StudentNumber = 1010,
                            TeacherID = "500",
                            TwoFactorEnabled = false,
                            UserID = "1"
                        },
                        new
                        {
                            Id = "d10a9da3-15cb-48c6-8f78-f320219c3b1e",
                            AccessFailedCount = 0,
                            Address = "367 S Limone St, Denver, CO, 80235",
                            Bio = "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus. Praesent aliquam in tellus eu.",
                            ConcurrencyStamp = "959f6529-7e63-4223-8862-65e19f0e0ef9",
                            DateOfBirth = new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailConfirmed = false,
                            FirstName = "Stacy",
                            InstrumentID = "pno",
                            LastName = "Miller",
                            LockoutEnabled = false,
                            MyClasses = "Piano, Choir",
                            Phone = "720-303-6367",
                            PhoneNumberConfirmed = false,
                            SchoolID = "HSM",
                            SecurityStamp = "9817647f-fa5d-4643-9b70-c1c5e7c9881c",
                            StudentNumber = 1011,
                            TeacherID = "300",
                            TwoFactorEnabled = false,
                            UserID = "2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.Image", b =>
                {
                    b.HasOne("CSC237_AHrechka_FinalProject.Models.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.PracticeLog", b =>
                {
                    b.HasOne("CSC237_AHrechka_FinalProject.Models.User", "User")
                        .WithMany("MyPractices")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("CSC237_AHrechka_FinalProject.Models.User", b =>
                {
                    b.HasOne("CSC237_AHrechka_FinalProject.Models.Instrument", "Instrument")
                        .WithMany()
                        .HasForeignKey("InstrumentID");

                    b.HasOne("CSC237_AHrechka_FinalProject.Models.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolID");

                    b.HasOne("CSC237_AHrechka_FinalProject.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CSC237_AHrechka_FinalProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CSC237_AHrechka_FinalProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSC237_AHrechka_FinalProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CSC237_AHrechka_FinalProject.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
