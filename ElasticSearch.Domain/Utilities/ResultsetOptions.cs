using ElasticSearch.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ElasticSearch.Domain.Utilities
{
    public static class ResultsetOptions
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                ResultCount = query.Count()
            };

            var skip = (page - 1) * pageSize;
            var pageCount = (double)result.ResultCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public static string RemoveAccentuation(String s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }


    }
}
