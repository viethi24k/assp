using b.Models;
using baiktra02.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        [Required
           ]
        public string Name { get; set; }
        [Required] 
        public double PRICE { get; set; }
        public string description { get; set; } 
        public string ImageURL { get; set; }    
        [Required ]
        public int TheLoaiID { get; set; }
        [ForeignKey("TheLoaiID")]      
        public Theloai theloai { get; set; }    
    }
}
