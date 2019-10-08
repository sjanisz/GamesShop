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
        private Service.Service service;

        public ProvinceController()
        {
            service = new Service.Service();
        }

        [HttpGet]
        [Route("api/provincesWithPlaces")]
        public IHttpActionResult GetProvincesWithPlaces()
        {
            List<Province> provinces = service.GetAllProvincesWithPlaces();

            if (provinces.Count == 0)
                return Content(HttpStatusCode.ServiceUnavailable, "Could not get provinces with places from database.");
            
            return Ok(provinces);
        }
    }
}