using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model
{
    public class Province
    {
        [Key]
        public int PROV_ID { get; set; }

        [Required]
        [MaxLength(20), MinLength(2)]
        public string PROV_NAME { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
