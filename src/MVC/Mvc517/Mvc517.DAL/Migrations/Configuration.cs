#define INIT 

namespace Mvc517.DAL.Migrations
{
    using Mvc517.DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mvc517.DAL.MvcDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mvc517.DAL.MvcDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

#if(!INIT)
            context.Operas.AddOrUpdate(
              new Opera {  Title="歌劇魅影", Year=1971, Composer="Stan" },
              new Opera { Title = "小美人魚", Year = 1990, Composer = "Disney" },
              new Opera { Title = "風中奇緣", Year = 2004, Composer = "Disney" }
            );
#endif

            context.SaveChanges();

        }
    }
}
