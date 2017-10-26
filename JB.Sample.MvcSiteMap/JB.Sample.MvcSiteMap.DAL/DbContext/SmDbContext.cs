using JB.Sample.MvcSiteMap.DAL.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JB.Sample.MvcSiteMap.DAL
{
    public class SmDbContext : JB.Production.Infra.Utility.EF.Context.BaseContext
    {
        
        public SmDbContext():base("name=SmDbContext")
        {
            
        }

        public DbSet<SmUser> SmUsers { get; set; }
        public DbSet<SmRole> SmRoles { get; set; }
        public DbSet<SmMenu> SmMenus { get; set; }
        public DbSet<SmUserRole> SmUserRoles { get; set; }
        public DbSet<SmRoleMenu> SmRoleMenus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ///EflowFormType 一對多 EflowFormSet
            //modelBuilder.Entity<EflowFormType>().HasMany(m => m.EflowFormSets).WithRequired(m => m.EflowFormType);
        }
    }
}
