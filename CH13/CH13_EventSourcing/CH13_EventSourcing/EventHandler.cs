namespace CH13_EventSourcing;

/// <summary>
/// EventHandler delegate
/// </summary>
public delegate void EventHandler<T>(T evt) where T : IEvent;

