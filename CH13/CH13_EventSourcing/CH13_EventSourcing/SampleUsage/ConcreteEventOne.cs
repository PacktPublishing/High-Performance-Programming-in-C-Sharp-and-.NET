using System.Collections.Concurrent;

namespace CH13_EventSourcing.SampleUsage
{
	public class ConcreteEventOne : IEvent
	{
		public int DataField;
	}
}
