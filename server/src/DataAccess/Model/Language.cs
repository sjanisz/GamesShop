using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Language
    {
        [Key]
        public int LANG_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string LANG_NAME { get; set; }

        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(512)]
        public string LANG_FLAG_URL { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
