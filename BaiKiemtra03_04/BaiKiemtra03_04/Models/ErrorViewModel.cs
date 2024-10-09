using System;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemtra03_04.Models
{

    public enum OrderStatus
    {
        Pending,
        Completed,
        Canceled,
        Shipped
    }
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
    }
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TotalValue { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [StringLength(20)]
        public OrderStatus Status { get; set; }

        public Supplier Supplier { get; set; } // Assuming a Supplier model exists
    }
}

