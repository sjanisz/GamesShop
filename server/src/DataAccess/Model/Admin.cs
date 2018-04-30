using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Admin
    {
        [Key]
        public int ADMIN_ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string ADMIN_LOGIN { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_FIRSTNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_LASTNAME { get; set; }

        [Required]
        [Column(TypeName = "char")]
        [StringLength(1, MinimumLength =1)]
        public string ADMIN_TYPE { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string ADMIN_PASSHASH { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string ADMIN_SALTHASH { get; set; }
    }
}
