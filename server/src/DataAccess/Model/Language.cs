using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class Language
    {
        [Key]
        public int LANG_ID { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string LANG_NAME { get; set; }

        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(512)]
        public string LANG_FLAG_URL { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
