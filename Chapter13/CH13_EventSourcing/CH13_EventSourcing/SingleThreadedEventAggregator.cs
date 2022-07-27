namespace CH13_EventSourcing
{
    /// <summary>
    /// Implements IEventAggregator
    /// </summary>
    public class SingleThreadedEventAggregator : IEventAggregator
    {

        IDictionary<Type, IList<EventHandler<IEvent>>> _eventHandlers;


        public SingleThreadedEventAggregator()
        {
            _eventHandlers = new Dictionary<Type, IList<EventHandler<IEvent>>>();
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
                foreach (EventHandler<IEvent> eventHandler in eventHandlerList)
                {
                    eventHandler.Invoke(evt);
                }
            }
        }
    }
}
