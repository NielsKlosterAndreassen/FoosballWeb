using System;
using System.Collections.Generic;
using EventSourcingTest.Interfaces;

namespace EventSourcingTest
{
	public class DomainBus : IBus
	{
		private readonly IList<Func<object>> _handlers = new List<Func<object>>();

		public void Raise<T>(T @event)
		{
			foreach (var handler in _handlers)
			{
				var h1 = handler() as Handles<T>;
				if (h1 != null)
				{
					h1.Handle(@event);
				}
			}
		}

		public void RegisterHandler(Func<object> p0)
		{
			_handlers.Add(p0);
		}
	}
}
