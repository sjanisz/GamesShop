using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class User
    {
        [Key]
        public int USER_ID { get; set; }

        [ForeignKey("Place")]
        public int PLACE_ID { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(15), MinLength(5)]
        [Index(IsUnique = true)]
        public string USER_LOGIN { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(320),MinLength(3)]
        [EmailAddress]
        public string USER_EMAIL { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string USER_FIRSTNAME { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string USER_LASTNAME { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string USER_STREET { get; set; }

        [Required]
        [MaxLength(10)]
        public string USER_FLAT { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(6), MinLength(6)]
        public string USER_POSTCODE { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string USER_PASSHASH { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string USER_PASSSALT { get; set; }

        [Required]
        public DateTime USER_REGDATE { get; set; }
        
        [Required]
        public Place Place { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
