using System.Web.Mvc.Ajax;

namespace KeepAlive.Web.Utilities
{
    public class AccountAjaxOptions : AjaxOptions
    {
        public AccountAjaxOptions()
        {
            OnSuccess = "account.success";
        }
    }
}
