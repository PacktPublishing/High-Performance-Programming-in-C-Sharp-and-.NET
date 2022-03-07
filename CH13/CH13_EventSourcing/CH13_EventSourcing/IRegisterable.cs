namespace CH13_EventSourcing
{
    /// <summary>
    /// Register an object with an IEventAggregator
    /// </summary>
    public interface IRegisterable
    {

        /// <summary>
        /// Registers the implementing object with an IEventAggregator instance
        /// </summary>
        /// <param name="eventAggregator">
        /// Local IEventAggregator instance
        /// </param>
        void RegisterWithEventAggregator(IEventAggregator eventAggregator);
    }
}
