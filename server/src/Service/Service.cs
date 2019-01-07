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
        /* Unnecessary for now
        public List<Place> GetAllPlaces()
        {
            List<Place> result = new List<Place>();

            using (var context = new ShopContext())
            {
                foreach (DataAccess.Model.Place place in context.Places.Include(p => p.Province).ToList())
                {
                    result.Add(new Place() { PlaceID = place.PLACE_ID, PlaceName = place.PLACE_NAME });
                }
            }

            return result;
        }
        */

        public List<Province> GetAllProvincesWithPlaces()
        {
            List<Province> result = new List<Province>();
            List<Place> places;

            using (var context = new ShopContext())
            {
                foreach(DataAccess.Model.Province province in context.Provinces.Include(p => p.Places).ToList())
                {
                    places = new List<Place>();

                    foreach(DataAccess.Model.Place place in province.Places)
                    {
                        places.Add(new Place() { PlaceID = place.PLACE_ID, PlaceName = place.PLACE_NAME});
                    }

                    result.Add(new Province() { ProvinceID = province.PROV_ID, ProvinceName = province.PROV_NAME, Places = new List<Place>(places) });
                }
            }

            return result;
        }
    }
}