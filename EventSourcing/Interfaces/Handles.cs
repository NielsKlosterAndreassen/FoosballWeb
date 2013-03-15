namespace EventSourcingTest.Interfaces
{
	public interface Handles<in T>
	{
		void Handle(T @event);
	}
}
