using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeepAlive.Identity.Validators
{
    public class UserValidator<TUser,TKey> : IIdentityValidator<IdentityUser>
    {
        public UserValidator(UserManager<IdentityUser, int> manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }
            AllowOnlyAlphanumericUserNames = true;
            Manager = manager;
        }

        private UserManager<IdentityUser, int> Manager { get; set; }

        private Regex userRegex = new Regex(@"^[A-Za-z0-9@_\.]+$");
        private Regex emailRegex = new Regex(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$");


        public bool AllowOnlyAlphanumericUserNames { get; set; }

        public bool RequireUniqueEmail { get; set; }

        public async Task<IdentityResult> ValidateAsync(IdentityUser item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var errors = new List<string>();
            //await ValidateUserName(item, errors).WithCurrentCulture();
            await ValidateUserName(item, errors);
            if (RequireUniqueEmail)
            {
                //await ValidateEmailAsync(item, errors).WithCurrentCulture();
                await ValidateEmailAsync(item, errors);
            }
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }
            return IdentityResult.Success;
        }

        private async Task ValidateUserName(IdentityUser user, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                //errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.PropertyTooShort, "Name"));
                errors.Add("Username non inserito");
            }
            else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, userRegex.ToString()))
            {
                // If any characters are not letters or digits, its an illegal user name
                //errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.InvalidUserName, user.UserName));
                errors.Add("Username non valido");
            }
            else
            {
                //var owner = await Manager.FindByNameAsync(user.UserName).WithCurrentCulture();
                var owner = await Manager.FindByNameAsync(user.UserName);
                if (owner != null && !EqualityComparer<int>.Default.Equals(owner.Id, user.Id))
                {
                    //errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.DuplicateName, user.UserName));
                    errors.Add("Username già inserito");
                }
            }
        }

        // make sure email is not empty, valid, and unique
        private async Task ValidateEmailAsync(IdentityUser user, List<string> errors)
        {
            //var email = await Manager.GetEmailStore().GetEmailAsync(user).WithCurrentCulture();
            //if (string.IsNullOrWhiteSpace(email))
            //{
            //    errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.PropertyTooShort, "Email"));
            //    return;
            //}
            //try
            //{
            //    var m = new MailAddress(email);
            //}
            //catch (FormatException)
            //{
            //    errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.InvalidEmail, email));
            //    return;
            //}

            if (!Regex.IsMatch(user.Email, emailRegex.ToString()))
            {
                errors.Add("Email non valida");
            }

            //var owner = await Manager.FindByEmailAsync(user.Email).WithCurrentCulture();
            var owner = await Manager.FindByEmailAsync(user.Email);
            if (owner != null && !EqualityComparer<int>.Default.Equals(owner.Id, user.Id))
            {
                //errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.DuplicateEmail, email));
                errors.Add("Non è possibile utilizzare l'email scelta");
            }
        }
    }
}
