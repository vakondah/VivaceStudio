﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class VivaceContext: IdentityDbContext<User>
    {
        public VivaceContext(DbContextOptions<VivaceContext> options) : base(options)
        {

        }
        
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PracticeLog> PracticeLog{ get; set; }
        public DbSet<Message> Messages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>().HasData(
                 new Teacher
                 {
                     TeacherID = "100",
                     FirstName = "Andrew",
                     LastName = "Rusinn",
                     Phone = "720 666-4567"
                 },
                new Teacher
                {
                    TeacherID = "200",
                    FirstName = "Maria",
                    LastName = "Ortega",
                    Phone = "720 122-0809"
                },
                new Teacher
                {
                    TeacherID = "300",
                    FirstName = "Lorena",
                    LastName = "Kirkland",
                    Phone = "720 898-3839"
                },
                new Teacher
                {
                    TeacherID = "400",
                    FirstName = "Olga",
                    LastName = "Kostenko",
                    Phone = "303 920 1764"
                },
                new Teacher
                {
                    TeacherID = "500",
                    FirstName = "John",
                    LastName = "Stivens",
                    Phone = "720 009-1890"
                });


            modelBuilder.Entity<School>().HasData(
                new School
                {
                    SchoolID = "RA",
                    SchoolName = "Rock Academy"
                },
                new School
                {
                    SchoolID = "HSM",
                    SchoolName = "Harmony School of Music"
                },
                new School
                {
                    SchoolID = "CPS",
                    SchoolName = "Centennial Piano School"
                });

            modelBuilder.Entity<Instrument>().HasData(
               new Instrument
               {
                   InstrumentID = "gtr",
                   InstrumentName = "Guitar"
               },
               new Instrument
               {
                   InstrumentID = "pno",
                   InstrumentName = "Piano"
               },
               new Instrument
               {
                   InstrumentID = "vln",
                   InstrumentName = "Violin"
               },
               new Instrument
               {
                   InstrumentID = "cel",
                   InstrumentName = "Cello"
               },
               new Instrument
               {
                   InstrumentID = "sax",
                   InstrumentName = "Saxophone"
               },
               new Instrument
               {
                   InstrumentID = "trg",
                   InstrumentName = "Triangle"
               }
               );


            modelBuilder.Entity<Image>()
                .HasOne(e => e.User)
                .WithMany(e => e.Images)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<PracticeLog>()
                .HasOne(e => e.User)
                .WithMany(e => e.MyPractices)
                .HasForeignKey(e => e.UserID);

            //1 to many relationship between User and Messages
            modelBuilder.Entity<Message>()
                .HasOne<User>(u => u.Sender)
                .WithMany(m => m.Messages)
                .HasForeignKey(u => u.UserID);
            
        }
    }
}
