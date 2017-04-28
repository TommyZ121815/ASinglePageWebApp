using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASinglePageWebApp.Data.Common
{
    public class SortExpression<T> where T : class
    {
        public SortExpression(Expression<Func<T, object>> sortBy, ListSortDirection sortDirection)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public Expression<Func<T, object>> SortBy { get; set; }
        public ListSortDirection SortDirection { get; set; }
    }
}
