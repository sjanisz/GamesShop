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
        [Route("api/provinces")]
        public List<Province> GetProvince()
        {
            Service.Service service = new Service.Service();
            return service.GetAllProvinces();
        }
    }
}