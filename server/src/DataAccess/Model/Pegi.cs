using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Pegi
    {
        [Key]
        public int PEGI_ID { get; set; }

        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(512)]
        public string PEGI_IMG_URL { get; set; }

        [Required]
        [Range(3, 21)]
        public int PEGI_VALUE { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
