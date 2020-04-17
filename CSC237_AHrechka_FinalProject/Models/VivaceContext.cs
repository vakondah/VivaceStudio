using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class VivaceContext: DbContext
    {
        public VivaceContext(DbContextOptions<VivaceContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        //public DbSet<Account> Accounts { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<PracticeLog> PracticeLog{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    StudentNumber = 1010,
                    //AccountID = 1,
                    FirstName = "Aliaksandra",
                    LastName = "Hrechka",
                    DateOfBirth = DateTime.Parse("2000-01-08"),
                    Bio = "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus." +
                         " Praesent aliquam in tellus eu.",
                    Address = "9999 E Orange St, Aurora, CO, 80011",
                    Email = "ahrechka@mail.com",
                    Phone = "970-777-7777",
                    SchoolID = 2,
                    TeacherID = 1,
                    InstrumentID = 1,
                    MyClasses = "Guitar, Choir"
                },
                new User
                {
                    UserID = 2,
                    StudentNumber = 1011,
                    //AccountID = 2,
                    FirstName = "Stacy",
                    LastName = "Miller",
                    DateOfBirth = DateTime.Parse("2007-12-18"),
                    Bio = "Aenean tortor est, vulputate quis leo in, vehicula rhoncus lacus." +
                            " Praesent aliquam in tellus eu.",
                    Address = "367 S Limone St, Denver, CO, 80235",
                    Email = "smiller16@mail.com",
                    Phone = "720-303-6367",
                    SchoolID = 3,
                    TeacherID = 3,
                    InstrumentID = 2,
                    MyClasses = "Piano, Choir"
                });
            modelBuilder.Entity<Teacher>().HasData(
                 new Teacher
                 {
                     TeacherID = 1,
                     FirstName = "Andrew",
                     LastName = "Rusinn",
                     Phone = "720 666-4567"
                 },
                new Teacher
                {
                    TeacherID = 2,
                    FirstName = "Maria",
                    LastName = "Ortega",
                    Phone = "720 122-0809"
                },
                new Teacher
                {
                    TeacherID = 3,
                    FirstName = "Lorena",
                    LastName = "Kirkland",
                    Phone = "720 898-3839"
                },
                new Teacher
                {
                    TeacherID = 4,
                    FirstName = "Olga",
                    LastName = "Kostenko",
                    Phone = "303 920 1764"
                },
                new Teacher
                {
                    TeacherID = 5,
                    FirstName = "John",
                    LastName = "Stivens",
                    Phone = "720 009-1890"
                });


            modelBuilder.Entity<School>().HasData(
                new School
                {
                    SchoolID = 1,
                    SchoolName = "Rock Academy"
                },
                new School
                {
                    SchoolID = 2,
                    SchoolName = "Harmony School of Music"
                },
                new School
                {
                    SchoolID = 3,
                    SchoolName = "Centennial Piano School"
                });
            modelBuilder.Entity<Instrument>().HasData(
               new Instrument
               {
                   InstrumentID = 1,
                   InstrumentName = "Guitar"
               },
               new Instrument
               {
                   InstrumentID = 2,
                   InstrumentName = "Piano"
               },
               new Instrument
               {
                   InstrumentID = 3,
                   InstrumentName = "Violin"
               },
               new Instrument
               {
                   InstrumentID = 4,
                   InstrumentName = "Chello"
               },
               new Instrument
               {
                   InstrumentID = 5,
                   InstrumentName = "Saxophone"
               },
               new Instrument
               {
                   InstrumentID = 6,
                   InstrumentName = "Triangle"
               }
               );

            
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    ImageID = 1,
                    UserID = 2,
                    ImageTitle = "crow.png",
                    ImageData = null
                },
                new Image
                {
                    ImageID = 2,
                    UserID = 1,
                    ImageTitle = "",
                    ImageData = null
                });



        }
    }
}
