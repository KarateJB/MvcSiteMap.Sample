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
    /// Role
    /// </summary>
    [Table("SmRoles")]
    public class SmRole : BaseEntity
    {
        /// <summary>
        /// Role ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SmRoleId { get; set; }
        /// <summary>
        /// Role name
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// Is enabled?
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
