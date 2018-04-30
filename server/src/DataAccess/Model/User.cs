using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class User
    {
        [Key]
        public int USER_ID { get; set; }

        [Required]
        [ForeignKey("Place")]
        public int PLACE_ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string USER_LOGIN { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(320)]
        public string USER_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string USER_FIRSTNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string USER_LASTNAME { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string USER_POSTCODE { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string USER_PASSHASH { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string USER_PASSSALT { get; set; }

        [Required]
        public DateTime USER_REGDATE { get; set; }
        
        [Required]
        public Place Place { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
