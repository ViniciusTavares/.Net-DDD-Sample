using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Contracts
{
   
        public interface IOrderByClause<T> where T : class, new()
        {
            IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort);
        }
}
