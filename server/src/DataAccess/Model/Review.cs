using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class Review
    {
        [Key, ForeignKey("User")]
        [Column(Order = 1)]
        public int USER_ID { get; set; }

        [Key, ForeignKey("Product")]
        [Column(Order = 2)]
        public int PROD_ID { get; set; }

        [Required]
        public DateTime REV_DATE { get; set; }

        public string REV_TEXT { get; set; }

        [Range(1,5)]
        public int REV_RATE { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
