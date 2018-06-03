using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KeepAlive.Web.Extensions.Internal
{
    public static class ExpressionExtension
    {
        public static string GetExpressionText<TModel>(this Expression<Func<TModel, Object>> expression)
        {
            var expr = (LambdaExpression)(expression);

            if (expr.Body.NodeType == ExpressionType.Convert)
            {
                //qui non devo usare il direct cast ma il trycast, per cui devo modificarlo
                var ue = (UnaryExpression)(expression.Body);

                //return string.Join(".", GetProperties(ue.Operand).[Select](p => p.name));
                return string.Join(".", GetProperties(ue.Operand).Select(p => p.Name));
            }

            return ExpressionHelper.GetExpressionText(expr);
        }

        private static IEnumerable<PropertyInfo> GetProperties(Expression expression)
        {
            var memberExpression = (MemberExpression)(expression);

            if (memberExpression == null)
            {
                yield break; 
            }

            var prop = (PropertyInfo)(memberExpression.Member);

            foreach (PropertyInfo propertyInfo in GetProperties(memberExpression.Expression))
            {
                yield return propertyInfo;
            }

            yield return prop;
        }
    }

    
}
