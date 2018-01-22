using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;


namespace Aim.Identity
{
    public class UserStore : IUserStore<ApplicationUser>
    {
        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            // TODO: get user info by id 这里需要实现获取用户信息的代码
            // var userInfo = appUserProfile.GetUserInfo(Guid.Parse(userId));

            return new ApplicationUser();
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            // TODO: get user info by id 这里需要实现获取用户信息的代码
            // var userInfo = appUserProfile.GetUserInfo(userName);

            return new ApplicationUser();
        }


        public Task CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
