using KeepAlive.Core.Contracts.Service;
using KeepAlive.Identity.Services;
using KeepAlive.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KeepAlive.Identity
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<IdentityUser, int>
    {

        private bool _disposed;

        public ApplicationUserManager(IUserStore<IdentityUser, int>  store) :base(store)
        {
            this.UserValidator = new Validators.UserValidator<IdentityUser, int>(this)
            {
                RequireUniqueEmail = true
            };
        }

        //public ApplicationUserManager(IUserStore<IdentityUser, int> store)
        //    : base(store)
        //{
        //    _store = store;
        //}

        //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        //{
        //    var userStore = DependencyResolver.Current.GetService<UserStore>();
        //
        //    var manager = new ApplicationUserManager(userStore);
        //
        //
        //    // Configure validation logic for usernames
        //    manager.UserValidator = new UserValidator<IdentityUser, int>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false,
        //        RequireUniqueEmail = true
        //    };
        //
        //    // Configure validation logic for passwords
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6,
        //        RequireNonLetterOrDigit = true,
        //        RequireDigit = true,
        //        RequireLowercase = true,
        //        RequireUppercase = true,
        //    };
        //
        //    // Configure user lockout defaults
        //    manager.UserLockoutEnabledByDefault = true;
        //    manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //    manager.MaxFailedAccessAttemptsBeforeLockout = 5;
        //
        //    // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
        //    // You can write your own provider and plug it in here.
        //    //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<IdentityUser, int>
        //    //{
        //    //    MessageFormat = "Your security code is {0}"
        //    //});
        //    manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<IdentityUser, int>
        //    {
        //        Subject = "Security Code",
        //        BodyFormat = "Your security code is {0}"
        //    });
        //    manager.EmailService = new EmailService();
        //    manager.SmsService = new SmsService();
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //    {
        //        manager.UserTokenProvider =
        //            new DataProtectorTokenProvider<IdentityUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    }
        //    return manager;
        //}

        public override Task<bool> IsEmailConfirmedAsync(int userId)
        {
            return base.IsEmailConfirmedAsync(userId);
        }

        public override async Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            ThrowIfDisposed();
            var passwordStore = GetPasswordStore();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            var result = await UpdatePassword(passwordStore, user, password).WithCurrentCulture();
            if (!result.Succeeded)
            {
                return result;
            }
            return await CreateAsync(user).WithCurrentCulture();
        }

        private IUserPasswordStore<IdentityUser, int> GetPasswordStore()
        {
            var cast = Store as IUserPasswordStore<IdentityUser, int>;
            if (cast == null)
            {
                throw new NotSupportedException(Resources.StoreNotIUserPasswordStore);
            }
            return cast;
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}
