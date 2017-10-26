using JB.Production.Infra.Utility.EF.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JB.Sample.MvcSiteMap.DAL.Models.DAO
{
    /// <summary>
    /// SmUserRole
    /// </summary>
    [Table("SmUserRoles")]
    public class SmUserRole : UowEntity
    {
        [Key]
        [Column(Order = 1)]
        public String SmUserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SmRoleId { get; set; }

        //Foreign Key
        [ForeignKey("SmUserId")]
        public virtual SmUser SmUser { get; set; }

        //Foreign Key
        [ForeignKey("SmRoleId")]
        public virtual SmRole SmRole { get; set; }
    }
}
