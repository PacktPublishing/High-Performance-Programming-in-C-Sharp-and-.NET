namespace CH13_EventSourcing
{
    /// <summary>
    /// Defines EventAggregator operations
    /// </summary>
    public interface IEventAggregator
    {

        /// <summary>
        /// Registers objects of type registerable.
        /// </summary>
        /// <param name="registerable">
        /// The IRegisterable object to be registered.
        /// </param>
        void Register(IRegisterable registerable);


        /// <summary>
        /// Registers an event handler associated with type T.
        /// </summary>
        /// <param name="eventHandler">
        /// Type of EventHandler
        /// </param>
        /// <typeparam name="T">
        /// Concrete event class
        /// </typeparam>
        void Register<T>(EventHandler<T> eventhandler) where T : IEvent;


        /// <summary>
        /// Raises an event via the delegate that handles the associated type.
        /// </summary>
        /// <param name="evt">
        /// The event object
        /// </param>
        void RaiseEvent(IEvent evt);
    }
}
