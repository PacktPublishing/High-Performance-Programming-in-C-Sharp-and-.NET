using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13_EventSourcing.SampleUsage
{
    public class EventHandlers : IRegisterable
    {

        string _name;


        public EventHandlers(string name)
        {
            _name = name;
        }


        public void RegisterWithEventAggregator(IEventAggregator eventAggregator)
        {
            eventAggregator.Register<ConcreteEventOne>(OnConcreteEventOne);
            eventAggregator.Register<ConcreteEventTwo>(OnConcreteEventTwo);
        }


        public void OnConcreteEventOne(ConcreteEventOne evt)
        {
            Console.WriteLine(_name + " got the sample event with message: [ DataField = " + evt.DataField + " ]");
        }


        public void OnConcreteEventTwo(ConcreteEventTwo evt)
        {
            Console.WriteLine(_name + " got the other sample event with message: [ DataField = " + evt.DataField + " ]");
        }
    }
}
