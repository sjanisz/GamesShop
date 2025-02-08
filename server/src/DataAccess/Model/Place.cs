using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class Place
    {
        [Key]
        public int PLACE_ID { get; set; }

        [Required]
        [ForeignKey("Province")]
        public int PROV_ID { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string PLACE_NAME { get; set; }

        public Province Province { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
