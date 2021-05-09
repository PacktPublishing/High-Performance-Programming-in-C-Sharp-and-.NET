namespace CH04_PreventingMemoryLeaks
{
    using System;
    using System.Diagnostics;
    using WeakEventListener;

    internal class UsingWeakReferences
	{
		public void RaiseWeakReferenceEvents()
		{
            bool isOnEventTriggered = false;
            bool isOnDetachTriggered = false;
            SampleClass sample = new SampleClass();
            WeakEventListener<SampleClass, object, EventArgs> weak = new WeakEventListener<SampleClass, object, EventArgs>(sample);
            weak.OnEventAction = (instance, source, eventArgs) => { isOnEventTriggered = true; };
            weak.OnDetachAction = (listener) => { isOnDetachTriggered = true; };
            sample.RaiseEvent += weak.OnEvent;
            sample.DoSomething();
            Debug.Assert(isOnEventTriggered);
            weak.Detach();
            Debug.Assert(isOnDetachTriggered);
        }
	}
}
