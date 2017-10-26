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
    /// SysUSer
    /// </summary>
    [Table("SmUsers")]
    public class SmUser : BaseEntity
    {
        /// <summary>
        /// System ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(300)]
        public String SmUserId { get; set; }


        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        [StringLength(200)]
        public String Name { get; set; }
        /// <summary>
        /// AD ID
        /// </summary>
        [Required]
        [StringLength(300)]
        public String AdUserId { get; set; }
        /// <summary>
        /// Is enabled ?
        /// </summary>
        [Required]
        public bool IsEnabled { get; set; }
    }
}
