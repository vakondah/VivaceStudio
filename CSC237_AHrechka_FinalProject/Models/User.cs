using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class User
    {
        
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public string Bio { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int StudentNumber { get; set; }
        public string MyClasses { get; set; }
        
        public Image Image { get; set; }
        public int SchoolID { get; set; }
        public School School { get; set; }

        public int InstrumentID { get; set; }
        public Instrument Instrument { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<PracticeLog> MyPractices { get; set; }

        public string FullName => FirstName + " " + LastName;
        public int Age => Convert.ToInt32(DateTime.Now.Year - DateOfBirth.Year);
    }
}
