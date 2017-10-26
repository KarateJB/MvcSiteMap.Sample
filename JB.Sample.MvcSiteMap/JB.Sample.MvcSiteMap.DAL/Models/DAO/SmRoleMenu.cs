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
    /// The relations between SysRole and SysMenu
    /// </summary>
    [Table("SmRoleMenus")]
    public class SmRoleMenu : UowEntity
    {
        /// <summary>
        /// SysRole ID
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public int SmRoleId { get; set; }
        /// <summary>
        /// SysMenu ID
        /// </summary>
        [Key]
        [Column(Order = 2)]
        public int SmMenuId { get; set; }

        //Foreign Key
        [ForeignKey("SmRoleId")]
        public virtual SmRole SmRole { get; set; }

        //Foreign Key
        [ForeignKey("SmMenuId")]
        public virtual SmMenu SmMenu { get; set; }
    }
}
