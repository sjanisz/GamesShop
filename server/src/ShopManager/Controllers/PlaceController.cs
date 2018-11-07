using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Service.Model;

namespace ShopManager.Controllers
{
    public class PlaceController : ApiController
    {
        [Route("api/places")]
        public List<Place> GetPlace()
        {
            Service.Service service = new Service.Service();
            return service.GetAllPlaces();
        }
    }
}
