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
              new Opera {  Title="�q�@�y�v", Year=1971, Composer="Stan" },
              new Opera { Title = "�p���H��", Year = 1990, Composer = "Disney" },
              new Opera { Title = "�����_�t", Year = 2004, Composer = "Disney" }
            );
#endif

            context.SaveChanges();

        }
    }
}
