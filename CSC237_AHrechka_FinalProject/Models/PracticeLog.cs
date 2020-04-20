using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class PracticeLog
    {
        public int PracticeLogID { get; set; }
        public DateTime Date { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime PracticeStartTime { get; set; }
        public DateTime PracticeEndTime { get; set; }
        public string Note { get; set; }
        public int UserID { get; set; }//FK
        public User User { get; set; }//navigation property
        public string Duration { get; set; }
        public bool InProgress { get; set; }



        //public int PracticeDuration => Convert.ToInt32(PracticeEndTime - PracticeStartTime);
    }
}
