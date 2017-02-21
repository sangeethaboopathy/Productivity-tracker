using ProductivityTracker_DataModel.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_DataAccess.Core
{
    public abstract class CommandHandlerBase<TCommand, TContext> : ICommandHandler<TCommand>, IDisposable
        where TCommand : class
        where TContext : DbContext
    {
        protected readonly TContext dbContext;

        protected CommandHandlerBase(TContext dbContextInput)
        {
            dbContext = dbContextInput;
        }

        public abstract void Execute(TCommand command);

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
