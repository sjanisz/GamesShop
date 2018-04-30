using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Producent
    {
        [Key]
        public int PRODUCENT_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string PRODUCENT_NAME { get; set; }

        [StringLength(200)]
        public string PRODUCENT_DESC { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string PRODUCENT_COUNTRY { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
