using System.Data.Entity.Migrations;
using ECommerceApp.Data;

namespace ECommerceApp.Data.Migrations
{
    public class ProductConfiguration
    {
        public static void Seed(ECommerceAppContext context) {

            context.SaveChanges();
        }
    }
}
