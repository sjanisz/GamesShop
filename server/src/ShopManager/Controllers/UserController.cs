using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopManager.Controllers
{
    public class UserController : ApiController
    {
        public string GetUsers()
        {
            return "users...dd";
        }

        public string Get(int a)
        {
            return a.ToString();
        }
    }
}
