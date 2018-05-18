using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KeepAlive.Web.Extensions.Html
{
    public static class SelectListExtensions
    {
        public static readonly SelectListItem DefaultEmptySelectListItem = new SelectListItem()
        {
            Text = "",
            Value = ""
        };

        public static IList<SelectListItem> ToSelectList<TSource, TKey>(this IEnumerable<TSource> enumerable,
                                                                        Func<TSource, TKey> key,
                                                                        Func<TSource, string> text,
                                                                        TKey currentKey,
                                                                        bool includedEmptyListItem = true)
        {
            List<TKey> currentKeys = new List<TKey>() { currentKey };
            IEnumerable<TKey> enumerableCurrentKeys = currentKeys;

            List<SelectListItem> selectList = new List<SelectListItem>();
            if (enumerable != null)
            {
                selectList = enumerable.Select(x => new SelectListItem()
                {
                    Value = key.Invoke(x).ToString(),
                    Text = text.Invoke(x),
                    Selected = (enumerableCurrentKeys != null && enumerableCurrentKeys.Contains(key.Invoke(x)))
                }).ToList();
            }

            if (includedEmptyListItem)
            {
                selectList.Insert(0, DefaultEmptySelectListItem);
            }

            return selectList;
        }
    }
}
