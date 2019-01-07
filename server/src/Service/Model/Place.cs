using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class Place
    {
        public int PlaceID { get; set; }
        public string PlaceName { get; set; }

        /* Unnecessary for now
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        */
    }
}