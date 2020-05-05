using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime TimeSent { get; set; }
        public Message()
        {
            TimeSent = DateTime.Now;
        }

        public string UserID { get; set; }
        public virtual User Sender { get; set; }
    }
}
