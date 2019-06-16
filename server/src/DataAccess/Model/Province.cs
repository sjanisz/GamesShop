using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
