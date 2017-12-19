using System.Data.Entity.Migrations;
using ECommerceApp.Data;

namespace ECommerceApp.Data.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(ECommerceAppContext context) {

            context.SaveChanges();
        }
    }
}
