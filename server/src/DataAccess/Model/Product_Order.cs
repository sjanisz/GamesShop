﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class Product_Order
    {
        [Key, ForeignKey("Order")]
        [Column(Order=1)]
        public int ORD_ID { get; set; }

        [Key, ForeignKey("Product")]
        [Column(Order = 2)]
        public int PROD_ID { get; set; }

        [Required]
        public int PO_AMOUNT { get; set; }

        [MaxLength(100)]
        public string PO_ADDITIONAL_INFO { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
