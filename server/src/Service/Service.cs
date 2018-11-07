using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Model;
using DataAccess;
using System.Data.Entity;

namespace Service
{
    public class Service
    {
        public List<Place> GetAllPlaces()
        {
            List<Place> result = new List<Place>();

            using (var context = new ShopContext())
            {
                foreach (DataAccess.Model.Place place in context.Places.Include(p => p.Province).ToList())
                {
                    result.Add(new Place() { PlaceName = place.PLACE_NAME, ProvinceName = place.Province.PROV_NAME });
                }
            }

            return result;
        }

        public List<Province> GetAllProvinces()
        {
            List<Province> result = new List<Province>();
            List<string> placeNames;

            using (var context = new ShopContext())
            {
                foreach(DataAccess.Model.Province province in context.Provinces.Include(p => p.Places).ToList())
                {
                    placeNames = new List<string>();

                    foreach(DataAccess.Model.Place place in province.Places)
                    {
                        placeNames.Add(place.PLACE_NAME);
                    }

                    result.Add(new Province() { ProvinceName = province.PROV_NAME, PlaceNames = new List<string>(placeNames) });
                }
            }

            return result;
        }
    }
}