using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class Province
    {
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public List<Place> Places { get; set; }
    }
}
