using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class SchoolInfo
    {
        public int StudentID { get; set; }
        public string MockSchoolName  { get; set; }// will be deleted
        public int SchoolID { get; set; }
        public School School { get; set; }
        public string  MockInstrument { get; set; }// will be deleted
        public int InstrumentID { get; set; }
        public Instrument Instrument { get; set; }
        public string MockTeacher { get; set; }// will be deleted
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public string MyClasses { get; set; }
    }
}
