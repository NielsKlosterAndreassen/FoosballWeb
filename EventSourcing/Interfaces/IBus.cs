using System;

namespace EventSourcingTest.Interfaces
{
	public interface IBus
	{
		void Raise<T>(T @event);
		void RegisterHandler(Func<object> p0);
	}
}
