using System;

namespace ProductivityTracker_DataModel.Core
{
	public interface ICommandHandler<in TCommand> : IDisposable
        where TCommand : class
    {
		void Execute(TCommand command);
	}
}