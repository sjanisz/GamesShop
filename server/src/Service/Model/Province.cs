using System.Collections.Generic;

namespace Service.Model
{
    // No need to verify there because users cannot create provinces, they are fixed in DB
    public class Province
    {
        public string ProvinceName { get; set; }

        public List<Place> Places { get; set; }
    }
}
