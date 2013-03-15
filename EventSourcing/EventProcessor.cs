using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventSourcingTest
{
    public class EventProcessor<T> where T : class
    {
        private readonly Action<T> _action;
		private readonly BlockingCollection<T> _queue = new BlockingCollection<T>();

        public EventProcessor(Action<T> action)
        {
            _action = action;
            Task.Factory.StartNew(Process);
        }

        public void Add(IEnumerable<T> @events)
        {
            foreach (var enlisted in @events)
                _queue.Add(enlisted);
        }

        public void Add(T @event)
        {
            _queue.Add(@event);
        }

        private void Process()
        {
            foreach (var @event in _queue)
            {
                _action(@event);
            }
        }
    }
}