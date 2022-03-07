using CH13_EventSourcing;
using CH13_EventSourcing.BankApp;
using CH13_EventSourcing.SampleUsage;
using EventHandlers = CH13_EventSourcing.BankApp.EventHandlers;

//Console.WriteLine("Begin event processing...");

//// create the event aggregator and the object
//// that contains the handler methods
//var singleThreadedEventAggregator = new SingleThreadedEventAggregator();
////var aggr = new EventAggregator.ConcurrentEventAggregator();
//var eventHandlerOne = new CH13_EventSourcing.SampleUsage.EventHandlers("1st set of event handlers");
//var eventHandlerTwo = new CH13_EventSourcing.SampleUsage.EventHandlers("2nd set of event handlers");

//singleThreadedEventAggregator.Register(eventHandlerOne);
//singleThreadedEventAggregator.Register(eventHandlerTwo);

//// create some mock events and set their sample values
//var concreteEventOne = new ConcreteEventOne();
//var concreteEventTwo = new ConcreteEventTwo();

//concreteEventOne.DataField = 1;
//concreteEventTwo.DataField = "Hello, world!";

//// trigger the events: 1st time
//singleThreadedEventAggregator.RaiseEvent(concreteEventOne);
//singleThreadedEventAggregator.RaiseEvent(concreteEventTwo);

//concreteEventOne.DataField = 2;
//concreteEventTwo.DataField = "Goodbye, world!";

//// trigger the events: 2st time
//singleThreadedEventAggregator.RaiseEvent(concreteEventTwo);
//singleThreadedEventAggregator.RaiseEvent(concreteEventOne);

//Console.WriteLine("Event processing completed.");

SingleThreadedEventAggregator eventAggregator = new();

EventHandlers eventHandlers = new("Payment Event Handlers");

DividendPayment dividendPayment = new DividendPayment { From = "Company Name", To = "Customer Name", PaymentDate = DateTime.Now, Amount = 23.45M };

StandingOrderPayment standingOrderPayment = new StandingOrderPayment { From = "Customer Name", To = "Company One", StartDate = DateOnly.Parse("25/02/2022") };

eventAggregator.Register(eventHandlers);

eventAggregator.RaiseEvent(dividendPayment);
eventAggregator.RaiseEvent(standingOrderPayment);




