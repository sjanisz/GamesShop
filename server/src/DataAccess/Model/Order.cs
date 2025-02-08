using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class Order
    {
        [Key]
        public int ORD_ID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int USER_ID { get; set; }

        public string ORD_INFO { get; set; }

        [Required]
        public DateTime ORD_DATE { get; set; }

        public User User { get; set; }

        public ICollection<Product_Order> Product_Order { get; set; }
    }
}
