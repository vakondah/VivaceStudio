﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class User : IdentityUser
    {
        
        public string UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int StudentNumber { get; set; }
        public string MyClasses { get; set; }
        public bool ShowPhoneNumber { get; set; }
        public bool ShowAge { get; set; }

        // navigation property 
        public ICollection<Image> Images { get; set; }

        public string SchoolID { get; set; }
        public School School { get; set; }

        public string InstrumentID { get; set; }
        public Instrument Instrument { get; set; }

        
        public string TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<PracticeLog> MyPractices { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public User()
        {
            Messages = new HashSet<Message>();
        }

        public string FullName => FirstName + " " + LastName;
        public int Age => Convert.ToInt32(DateTime.Now.Year - DateOfBirth.Year);
    }
}
