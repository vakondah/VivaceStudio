using System;
using System.Collections.Generic;
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
        public int ImageID { get; set; }
        public Image Image { get; set; }
        public int StudentID { get; set; }
        public SchoolInfo SchoolInfo { get; set; }
        public int AccountID { get; set; }
        public Account Account { get; set; }

        public string FullName => FirstName + " " + LastName;
        public int Age => Convert.ToInt32(DateTime.Now.Year - DateOfBirth.Year);
    }
}
