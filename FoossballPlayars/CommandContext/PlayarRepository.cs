using System;
using System.Collections.Generic;
using EventSourcingTest;
using EventSourcingTest.Interfaces;

namespace FoossballPlayars.CommandContext
{
    public class PlayarRepository : Repository<Playar>, IRepository<Playar>
	{
        public PlayarRepository(IBus eventBus) : base(eventBus)
        {
        }

        protected override Playar CreateInstance(Guid id, IEnumerable<object> events)
		{
			return new Playar(id, events);
		}
	}
}