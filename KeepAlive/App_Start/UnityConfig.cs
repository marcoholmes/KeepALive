using KeepAlive.Core.Contracts.Data;
using KeepAlive.Core.Contracts.Service;
using KeepAlive.Data;
using KeepAlive.Identity;
using KeepAlive.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using Unity;
using Unity.Injection;

namespace KeepAlive
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        /// 

        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            IdentityRegisterTypes(container);
            ServiceRegisterTypes(container);
            DataRegisterTypes(container);
        }

        public static void IdentityRegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            container.RegisterType<IUserStore<IdentityUser, int>, UserStore>();
            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(
                    o => System.Web.HttpContext.Current.GetOwinContext().Authentication));
            
        }

        public static void ServiceRegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAccountService, AccountService>();
        }

        public static void DataRegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAccountData, AccountData>();
        }
    }
}