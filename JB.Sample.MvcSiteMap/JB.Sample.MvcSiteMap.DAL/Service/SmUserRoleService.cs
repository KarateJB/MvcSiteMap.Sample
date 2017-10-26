﻿using JB.Sample.MvcSiteMap.DAL.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JB.Sample.MvcSiteMap.DAL.Service
{
    public class SmUserRoleService<T> : JB.Production.Infra.Utility.EF.Service.BaseDalService<T> where T : SmUserRole
    {
        public SmUserRoleService(DbContext dbContext) : base(dbContext)
        {
            dbContext.Set<SmUserRole>().AsNoTracking();
        }
    }
}