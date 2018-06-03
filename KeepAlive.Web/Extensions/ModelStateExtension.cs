using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using KeepAlive.Web.Extensions.Internal;

namespace KeepAlive.Web.Extensions
{
    public static class ModelStateExtension
    {
        static public void AddModelError<TModel>(this ModelStateDictionary modelState,
                                          Expression<Func<TModel, Object>> expression,
                                          string errorMessage)
        {
            string key = ExpressionExtension.GetExpressionText(expression);
            string message = String.Format(errorMessage, key);
            modelState.AddModelError(key, message);
        }
    }
}
