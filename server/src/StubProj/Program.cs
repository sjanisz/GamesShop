using System;
using DataAccess;

namespace StubProj
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShopContext())
            {
                //List<DataAccess.Model.Place> places = new List<DataAccess.Model.Place>();
                //DataAccess.Model.User user = new DataAccess.Model.User
                //{
                //    //get places to some enum?
                //    USER_LOGIN = "sampleUser2",
                //    //implement salt-hash
                //    USER_PASSHASH = "hash",
                //    USER_PASSSALT = "salt",
                //    USER_REGDATE = DateTime.Now,
                //    USER_EMAIL = "asd@asd.com",
                //    USER_FIRSTNAME = "fname",
                //    USER_LASTNAME = "sname",
                //    USER_POSTCODE = "11",
                //    Place = context.Places.FirstOrDefault(p => p.PLACE_NAME == "Rzeszów")
                //};
                //context.Users.Add(user);

                //var result = context.Places.Include(p => p.Province).ToList();
                
                context.SaveChanges();
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
