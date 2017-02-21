using ProductivityTracker_DataModel.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_DataAccess.Core
{
    public abstract class QueryBase<TContext> : IQuery
        where TContext : DbContext
    {
        protected readonly TContext dbContext;

        protected QueryBase(TContext dbContextInput)
        {
            dbContext = dbContextInput;
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
