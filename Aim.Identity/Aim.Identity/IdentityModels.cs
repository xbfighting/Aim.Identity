using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aim.Identity
{
    /// <summary>
    /// ApplicationUser
    /// </summary>
    public class ApplicationUser : IUser
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户登录名
        /// </summary>
        public string UserName { get; set; }

        #region 自定义属性

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string UserTrueName { get; set; }

        /// <summary>
        /// 承租区域
        /// </summary>

        public string Tenant { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public ApplicationRole UserRole { get; set; }

        // ... more extension fields

        #endregion

        /// <summary>
        /// 生成用户身份信息
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // 在此处添加自定义用户声明
            userIdentity.AddClaim(new Claim("CurrentUser", JsonConvert.SerializeObject(this)));

            return userIdentity;
        }
    }

    /// <summary>
    /// ApplicationRole
    /// </summary>
    public class ApplicationRole : IRole
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }


        #region 自定义属性
        
        // ... more extension fields

        #endregion
    }
}
