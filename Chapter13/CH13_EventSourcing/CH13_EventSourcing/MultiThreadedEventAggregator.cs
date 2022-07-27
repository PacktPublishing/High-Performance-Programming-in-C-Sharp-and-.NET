using System.Collections.Concurrent;

namespace CH13_EventSourcing
{
    /// <summary>
    /// Implements IEventAggregator
    /// </summary>
    public class MultiThreadedEventAggregator : IEventAggregator
    {

        IDictionary<Type, IList<EventHandler<IEvent>>> _eventHandlers;


        public MultiThreadedEventAggregator()
        {
            _eventHandlers = new ConcurrentDictionary<Type, IList<EventHandler<IEvent>>>();
        }


        public void Register(IRegisterable registerable)
        {
            registerable.RegisterWithEventAggregator(this);
        }


        public void Register<T>(EventHandler<T> eventHandler) where T : IEvent
        {
            if (!_eventHandlers.ContainsKey(typeof(T)))
            {
                _eventHandlers[typeof(T)] = new List<EventHandler<IEvent>>();
            }

            var eventHandlerList = _eventHandlers[typeof(T)];

            eventHandlerList.Add(evt => eventHandler((T)evt));
        }


        public void RaiseEvent(IEvent evt)
        {
            IList<EventHandler<IEvent>> eventHandlerList;

            if (_eventHandlers.TryGetValue(evt.GetType(), out eventHandlerList))
            {
                Parallel.ForEach(eventHandlerList, eventHandler =>
               {
                   eventHandler.Invoke(evt);
               });
            }
        }
    }
}
