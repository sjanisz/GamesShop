﻿using System;
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
        [MaxLength(20), MinLength(2)]
        public string PRODUCENT_NAME { get; set; }

        [MaxLength(200)]
        public string PRODUCENT_DESC { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(50), MinLength(2)]
        public string PRODUCENT_COUNTRY { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
