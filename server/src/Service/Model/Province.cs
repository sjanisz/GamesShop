using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    // No need to verify there because users cannot create provinces, they are fixed in DB
    public class Province
    {
        public string ProvinceName { get; set; }

        public List<Place> Places { get; set; }
    }
}
