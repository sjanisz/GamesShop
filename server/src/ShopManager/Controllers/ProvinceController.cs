using System.Collections.Generic;
using System.Net;
using System.Web.Http;
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
            return Ok("=)");

            List<Province> provinces = service.GetAllProvincesWithPlaces();

            if (provinces.Count == 0)
                return Content(HttpStatusCode.ServiceUnavailable, "Could not get provinces with places from database.");
            
            return Ok(provinces);
        }
    }
}