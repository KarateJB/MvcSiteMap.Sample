using JB.Sample.MvcSiteMap.DAL.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JB.Sample.MvcSiteMap.DAL.Service
{
    public class SmMenuService<T> : JB.Production.Infra.Utility.EF.Service.BaseDalService<T> where T : SmMenu
    {
        public SmMenuService(DbContext dbContext) : base(dbContext)
        {
            dbContext.Set<SmMenu>().AsNoTracking();
        }
    }
}
