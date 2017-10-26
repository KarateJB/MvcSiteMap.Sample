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
    /// System Menu
    /// </summary>
    [Table("SmMenus")]
    public class SmMenu : BaseEntity
    {
        /// <summary>
        /// Menu ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SmMenuId { get; set; }

        /// <summary>
        /// Menu title (zh-TW)
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Menu title (zh-CN)
        /// </summary>
        [Required]
        [StringLength(200)]
        public string NameCn { get; set; }

        /// <summary>
        /// Menu title (en-US)
        /// </summary>
        [Required]
        [StringLength(200)]
        public string NameUs { get; set; }


        /// <summary>
        /// Area
        /// </summary>
        [StringLength(100)]
        public string Area { get; set; }

        /// <summary>
        /// Controller name
        /// </summary>
        [StringLength(100)]
        public string Controller { get; set; }

        /// <summary>
        /// Action name
        /// </summary>
        [StringLength(100)]
        public string Action { get; set; }

        /// <summary>
        /// the redirect Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// The parent id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// The route values
        /// </summary>
        public string RouteValues { get; set; }

        /// <summary>
        /// Order serial number
        /// </summary>
        public int? OrderSn { get; set; }

        /// <summary>
        /// Is enabled?
        /// </summary>
        public bool IsEnabled { get; set; }

    }
}
