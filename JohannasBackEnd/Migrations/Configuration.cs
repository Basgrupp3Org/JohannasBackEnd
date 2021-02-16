namespace JohannasBackEnd.Migrations
{
    using JohannasBackEnd.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JohannasBackEnd.Domain.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JohannasBackEnd.Domain.MyDBContext context)
        {

            context.Balances.AddOrUpdate(new Balance()
            {
                Sum = 10,
                Date = DateTime.Now,
                BalanceLabel = "Salary",
                User = context.Users.Where(u => u.UserName == "Kardo").FirstOrDefault()


            }); 
        //    context.Users.AddOrUpdate(new User()
        //    {
        //        UserName = "Admin",

        //        Password = "Password"


        //    });



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
