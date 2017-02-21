namespace ProductivityTracker_DataModel.Core
{
	public interface ICommandsFactory
	{
		void ExecuteCommand<T>(T command)
			where T : class;
	}
}