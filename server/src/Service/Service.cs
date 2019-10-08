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
                        places.Add(new Place() {PlaceName = place.PLACE_NAME, ProvinceName = province.PROV_NAME});
                    }

                    result.Add(new Province() { ProvinceName = province.PROV_NAME, Places = new List<Place>(places) });
                }
            }

            return result;
        }
        
        public bool RegisterUser(string login, string password, string email, string firstName, string lastName,
            string street, string flatNumber, string postCode, int provinceId, string placeName)
        {
            // TODO: validation here

            // login
            // length: 5-15 characters
            // loginRegex: /(?=[^0-9])(?=[^a-z])(?=[^A-Z])/;
            if ((login.Length < 5) || (login.Length > 15))
            {
                //throw new HttpResponseException("Customer Name cannot be empty", HttpStatusCode.BadRequest)
            }

            //Place validation - temporary just add to database, in future admin must check the place name before
            //it will be added to hint GUI textbox (e.g. to avoid vulgarisms)

            using (var context = new ShopContext())
            {
                List<DataAccess.Model.Place> places;



                try
                {
                    places = context.Provinces.Include(p => p.Places).First(p => p.PROV_ID == provinceId).Places.ToList();
                }
                catch (ArgumentNullException exception)
                {
                    throw new Exception("Failed to retrieve province with id " + provinceId, exception);
                }

                DataAccess.Model.Place place = places.FirstOrDefault(p => p.PLACE_NAME == placeName);

                if (place == null)
                {
                    DataAccess.Model.Place newPlace = new DataAccess.Model.Place()
                    {
                        PLACE_NAME = placeName,
                        Province = context.Provinces.First(p => p.PROV_ID == provinceId)
                    };
                }

                //public string USER_PASSHASH { get; set; }
                //public string USER_PASSSALT { get; set; }
                //public DateTime USER_REGDATE { get; set; }

                DataAccess.Model.User user = new DataAccess.Model.User()
                {
                    USER_LOGIN = login,//must be unique, handle exception?
                    USER_EMAIL = email,//do not have to be unique, validate format?
                    USER_FIRSTNAME = firstName,
                    USER_LASTNAME = lastName,
                    USER_STREET = street,
                    USER_FLAT = flatNumber,
                    USER_POSTCODE = postCode,
                    Place = place
                };
            }

            throw new NotImplementedException();
        }
    }
}