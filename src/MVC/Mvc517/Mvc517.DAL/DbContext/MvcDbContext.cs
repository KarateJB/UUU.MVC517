using Mvc517.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc517.DAL
{
    public class MvcDbContext : DbContext
    {
        public MvcDbContext() : base("name=MvcDbContext")
        {

        }

        public DbSet<Opera> Operas { get; set; }
    }
}
