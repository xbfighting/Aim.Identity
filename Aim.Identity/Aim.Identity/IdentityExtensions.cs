using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aim.Identity
{
    /// <summary>
    /// Identity Extensions
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        /// 当前用户信息
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static ApplicationUser GetCurrentUser(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("CurrentUser");
            return (claim != null) ? JsonConvert.DeserializeObject<ApplicationUser>(claim.Value) : null;
        }

        /// <summary>
        /// 当前用户角色信息
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static List<ApplicationRole> GetCurrentRoles(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("CurrentRoles");
            return (claim != null) ? JsonConvert.DeserializeObject<List<ApplicationRole>>(claim.Value) : null;
        }
    }
}
