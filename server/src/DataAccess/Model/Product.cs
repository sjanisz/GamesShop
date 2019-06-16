using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Product
    {
        [Key]
        public int PROD_ID { get; set; }

        [ForeignKey("Pegi")]
        public int PEGI_ID { get; set; }

        [Required]
        [ForeignKey("Producent")]
        public int PRODUCENT_ID { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string PROD_NAME { get; set; }

        [Required]
        [Column(TypeName ="Money")]
        public decimal PROD_PRICE { get; set; }

        [Required]
        public int PROD_AVAILABLE_AMOUNT { get; set; }

        [MaxLength(200)]
        public string PROD_DESC { get; set; }

        [Column(TypeName ="VARCHAR")]
        [MaxLength(512)]
        public string PROD_VID_URL { get; set; }

        public Pegi Pegi { get; set; }
        public Producent Producent { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Language> Languages { get; set; } 
        public ICollection<Product_Order> Product_Order { get; set; }     
    }
}
