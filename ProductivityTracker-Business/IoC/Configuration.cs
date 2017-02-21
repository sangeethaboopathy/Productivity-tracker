#region Dependencies
using Ninject.Modules;
using ProductivityTracker_DataAccess.Context;
using ProductivityTracker_DataModel.Core;

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
            // Dashboard Queries 
            //Bind<IGetEmpInforDashboardQuery>().To<GetEmpInforDashboardQuery>().InTransientScope();
            

            #endregion

            #region Commands
            // Commands
            // Application Home Commands
            //Bind<ICommandHandler<SaveFeedbackCommand>>().To<SaveFeedbackCommandHandler>().InTransientScope();
            
            #endregion
        }
    }
}
