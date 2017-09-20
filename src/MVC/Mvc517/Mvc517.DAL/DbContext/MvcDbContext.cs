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
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            ///BlsDepartment 一對多 BlsOwnership
            //modelBuilder.Entity<BlsCompany>().HasMany(m => m.BlsDepartments).WithRequired(m => m.BlsOwnership);

            #region 設定Foreign Key非必要
            modelBuilder.Entity<Opera>().Property(x => x.CommentId).IsOptional();
            #endregion 
        }


        
    }
}
