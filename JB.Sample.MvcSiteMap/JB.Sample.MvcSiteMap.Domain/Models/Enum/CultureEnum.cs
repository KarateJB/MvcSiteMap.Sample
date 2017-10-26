using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JB.Sample.MvcSiteMap.Domain.Models.Enum
{
    public enum CultureEnum
    {
        /// <summary>
        /// 中文(繁體)
        /// </summary>
        [Description("zh-TW")]
        zhTW = 0,

        /// <summary>
        /// 中文(简体)
        /// </summary>
        [Description("zh-CN")]
        zhCN,

        /// <summary>
        /// 英文
        /// </summary>
        [Description("en-US")]
        enUS
    }
}
