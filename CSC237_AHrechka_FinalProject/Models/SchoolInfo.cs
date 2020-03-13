using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class SchoolInfo
    {
        public int StudentID { get; set; }
        public School School { get; set; }
        public Instrument Instrument { get; set; }
        public Teacher Teacher { get; set; }
    }
}
