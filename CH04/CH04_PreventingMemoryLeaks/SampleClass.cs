namespace CH04_PreventingMemoryLeaks
{
    using System; 

    internal class SampleClass
    {
        public event EventHandler<EventArgs> RaiseEvent;

        public void DoSomething()
        {
            OnRaiseEvent();
        }

        protected virtual void OnRaiseEvent()
        {
            RaiseEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
