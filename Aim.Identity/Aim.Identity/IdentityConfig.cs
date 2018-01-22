using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Aim.Identity
{
    /// <summary>
    /// ApplicationUserManager
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        /// <summary>
        /// default gen
        /// </summary>
        /// <param name="store"></param>
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore());
            return manager;
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            //var appAccount = new SysAccountApplication();
            //var appUserProfile = new SysUserProfileApplication();

            // Guid userId = appAccount.CheckLogin(userName, password);
            Guid userId = new Guid();
            if (userId != Guid.Empty)
            {

                //var userInfo = appUserProfile.GetUserInfo(userId);

                return Task.Run(() => {
                    return new ApplicationUser
                    {
                        //..
                    };
                });
            }
            return Task.Run(() => { return new ApplicationUser(); });
        }

        /// <summary>
        /// 获取客户端登录IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            try
            {
                string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(result))
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = HttpContext.Current.Request.UserHostAddress;
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }

    /// <summary>
    /// 配置要在此应用程序中使用的应用程序登录管理器。
    /// </summary>
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationUserManager manager { get; set; }
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            manager = userManager;
        }

        /// <summary>
        /// 创建登录凭据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="isPersistent"></param>
        /// <returns></returns>
        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await user.GenerateUserIdentityAsync(manager);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        /// <summary>
        /// 退出
        /// </summary>
        public void SignOut()
        {
            AuthenticationManager.SignOut();
        }


        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    /// <summary>
    /// 角色管理
    /// </summary>
    public class ApplicationRoleManage : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManage(IRoleStore<ApplicationRole> store)
            : base(store)
        {
        }
        public static ApplicationRoleManage Create(IdentityFactoryOptions<ApplicationRoleManage> options, IOwinContext context)
        {
            return new ApplicationRoleManage(new RoleStore());
        }
    }
}
