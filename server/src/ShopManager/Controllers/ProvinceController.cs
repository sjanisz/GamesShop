using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Service.Model;

namespace ShopManager.Controllers
{
    public class ProvinceController : ApiController
    {
        [Route("api/provincesWithPlaces")]
        public List<Province> GetProvincesWithPlaces()
        {
            Service.Service service = new Service.Service();
            return service.GetAllProvincesWithPlaces();
        }
    }
}