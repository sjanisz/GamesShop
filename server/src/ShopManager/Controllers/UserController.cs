using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Service.Model;

namespace ShopManager.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/users")] 
        public string GetUsers() // todo: change return to List<User>
        {
            throw new NotImplementedException();
        }

        [Route("api/users/{a}")]
        public string GetUser(int a)
        {
            throw new NotImplementedException();
        }

        [Route("api/users")]
        public bool RegisterUser()
        {

        }
    }
}
