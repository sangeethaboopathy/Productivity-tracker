using ProductivityTracker_Business.Interface;
using ProductivityTracker_Business.IoC;
using ProductivityTracker_DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTracker_Business.Executors
{
    public class BaseExecutors : IBaseExecutor
    {
        protected IQueryFactory queryFactory = Container.Current.Resolve<IQueryFactory>();
        protected ICommandsFactory commandsFactory = Container.Current.Resolve<ICommandsFactory>();
    }
}
