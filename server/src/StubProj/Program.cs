using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace StubProj
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShopContext())
            {
                /*DataAccess.Model.Admin Admin = new DataAccess.Model.Admin
                {
                    ADMIN_FIRSTNAME = "TEST",
                    ADMIN_LASTNAME = "TEST",
                    ADMIN_TYPE = "S",
                    ADMIN_LOGIN = "admin",
                    ADMIN_PASSHASH = "admin",
                    ADMIN_SALTHASH = "admin"
                };

                context.Admins.Add(Admin);*/
                List<DataAccess.Model.Place> places = new List<DataAccess.Model.Place>();

                DataAccess.Model.User user = new DataAccess.Model.User
                {
                    //get places to some enum?
                    USER_LOGIN = "sampleUser2",
                    //implement salt-hash
                    USER_PASSHASH = "hash",
                    USER_PASSSALT = "salt",
                    USER_REGDATE = DateTime.Now,
                    USER_EMAIL = "asd@asd.com",
                    USER_FIRSTNAME = "fname",
                    USER_LASTNAME = "sname",
                    USER_POSTCODE = "11",
                    Place = context.Places.FirstOrDefault(p => p.PLACE_NAME == "Rzeszów")
                };
                context.Users.Add(user);
                
                context.SaveChanges();
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
