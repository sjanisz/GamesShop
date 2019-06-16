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
        [MaxLength(15), MinLength(2)]
        public string ADMIN_LOGIN { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string ADMIN_FIRSTNAME { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string ADMIN_LASTNAME { get; set; }

        [Required]
        [Column(TypeName = "char")]
        [MaxLength(1), MinLength(1)]
        public string ADMIN_TYPE { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100), MinLength(1)]
        public string ADMIN_PASSHASH { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100), MinLength(1)]
        public string ADMIN_SALTHASH { get; set; }
    }
}
