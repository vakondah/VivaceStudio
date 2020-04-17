using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSC237_AHrechka_FinalProject.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public int UserID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public User User { get; set; }

        
    }
}
