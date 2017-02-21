namespace ProductivityTracker_DataModel.Core
{
	public interface IQueryFactory
	{
		T ResolveQuery<T>()
			where T : class, IQuery;
	}
}