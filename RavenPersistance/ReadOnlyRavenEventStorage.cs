using System;
using System.Collections.Generic;
using EventSourcingTest;
using EventSourcingTest.Interfaces;

namespace RavenPersistance
{
	public class ReadOnlyRavenEventStorage : RaventEventStorage
	{
		public ReadOnlyRavenEventStorage(IDocumentStoreFactory storeFactory, IBus eventBus) : base(storeFactory, eventBus)
		{
		}

		public override void Append<TAggregateRoot>(Guid id, IEnumerable<Event> events)
		{
			
		}
	}
}