using System;
using System.Collections.Generic;
using System.Linq;
using ManyToManyTest.Model;

namespace ManyToManyTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (MTMContext db = new DbFactory().CreateDbContext(null))
            {
                //User user = db.Users.Find(1);
                //Product product = db.Products.Find(1);

                //db.UserProducts.Add(new UserProduct
                //{
                //    User = user,
                //    Product = product,
                //});

                //db.SaveChanges();

                List<Product> products = db.Users.Find(1).Products.Select(model => model.Product).ToList();
            }

            

        }
    }
}
