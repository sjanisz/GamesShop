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
                DataAccess.Model.Admin Admin = new DataAccess.Model.Admin
                {
                    ADMIN_FIRSTNAME = "TEST",
                    ADMIN_LASTNAME = "TEST",
                    ADMIN_TYPE = "S",
                    ADMIN_LOGIN = "admin",
                    ADMIN_PASSHASH = "admin",
                    ADMIN_SALTHASH = "admin"
                };

                context.Admins.Add(Admin);
                
                context.SaveChanges();
            }
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
