using System;
using System.Collections.Generic;
using System.Linq;

namespace OngProject.Core.Helper
{
    public class PageHelper<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => (CurrentPage > 1);
        public bool IsPrevious => (CurrentPage < TotalPages);


        public PageHelper(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            TotalPages = pageNumber;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            AddRange(items);
        }

        public static PageHelper<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PageHelper<T>(items, count, pageNumber, pageSize);
        }
    }
}
