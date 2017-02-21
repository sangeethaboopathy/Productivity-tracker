#region Dependencies
using Ninject.Modules;
using ProductivityTracker_DataAccess.CommandHandlers.Account;
using ProductivityTracker_DataAccess.Context;
using ProductivityTracker_DataAccess.QueryExecutors.Dashboard;
using ProductivityTracker_DataAccess.QueryExecutors.Login;
using ProductivityTracker_DataModel.Commands.Account;
using ProductivityTracker_DataModel.Core;
using ProductivityTracker_DataModel.Queries.Dashboard;
using ProductivityTracker_DataModel.Queries.Login;

#endregion

namespace ProductivityTracker_Business.IoC
{
    public class Configuration : NinjectModule
    {
        public override void Load()
        {
            // Infrastructure
            Bind<IQueryFactory>().ToMethod(t => new QueryFactory(x => Container.Current.Resolve(x))).InTransientScope();
            Bind<ICommandsFactory>()
                .ToMethod(t => new CommandFactory(x => (object[])Container.Current.ResolveAll(x)))
                .InTransientScope();

            // dbContext
            Bind<SqlServerContext>().ToSelf();

            #region Queries
            // Queries
            Bind<IVerifyLogin>().To<VerifyLogin>().InTransientScope();
            Bind<IGetAccountInfoQuery>().To<GetAccountInfoQuery>().InTransientScope();

            #endregion

            #region Commands
            // Commands
            Bind<ICommandHandler<UploadAccountsCommand>>().To<UploadAccountsCommandHandler>().InTransientScope();
            Bind<ICommandHandler<PickAccountCommand>>().To<PickAccountCommandHandler>().InTransientScope();
            Bind<ICommandHandler<CompleteAccountCommand>>().To<CompleteAccountCommandHandler>().InTransientScope();

            #endregion
        }
    }
}
