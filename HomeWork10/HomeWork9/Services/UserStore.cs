using HomeWork9.DomainClasses;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HomeWork9.Services
{
    public class UserStore : IUserStore<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>,
        IUserSecurityStampStore<ApplicationUser>
    {
        // Not implemented in this example, use EF asnyc
        public async Task CreateAsync(ApplicationUser user)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // Not implemented in this example, use EF asnyc
        public async Task DeleteAsync(ApplicationUser user)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            await Task.Delay(0);

            ApplicationUser user = null;

            if (userId == "1")
            {
                user = new ApplicationUser();
                user.Id = "1";
                user.UserName = "admin";
            }

            return user;
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            await Task.Delay(0);

            ApplicationUser user = null;

            if (userName == "admin")
            {
                user = new ApplicationUser();
                user.Id = "1";
                user.UserName = "admin";
            }

            return user;
        }

        // Not implemented in this example, use EF asnyc
        public async Task UpdateAsync(ApplicationUser user)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            await Task.Delay(0);

            if (user.Id == "1")
            {
                // Hash for "password"
                return "ADkPKi0mACIBxyl1rRv2VVjnw83jG3JZEL2XyKJM5ffpFtlKNq70pMgobayb9nd7tQ==";
            }

            throw new ApplicationException("Invalid user.");
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            await Task.Delay(0);

            if (user.Id == "1")
            {
                return true;
            }

            throw new ApplicationException("Invalid identity user.");
        }

        // Not implemented in this example, use EF asnyc
        public async Task SetPasswordHashAsync(
            ApplicationUser user,
            string passwordHash)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<string> GetSecurityStampAsync(
            ApplicationUser user)
        {
            await Task.Delay(0);

            if (user.Id == "1")
            {
                return "0EB32F4F-2C30-40B7-8EAB-09000836833B";
            }

            throw new ApplicationException("Invalid identity user.");
        }

        // Not implemented in this example, use EF asnyc
        public async Task SetSecurityStampAsync(
            ApplicationUser user,
            string stamp)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // No dispose implementation required in this example
        public void Dispose()
        {
        }
    }
}