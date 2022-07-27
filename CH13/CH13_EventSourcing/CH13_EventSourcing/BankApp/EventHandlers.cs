namespace CH13_EventSourcing.BankApp
{
    internal sealed class EventHandlers : IRegisterable
    {
        public string Name { get; }


        public EventHandlers(string name)
        {
            Name = name;
        }

        public void RegisterWithEventAggregator(IEventAggregator eventAggregator)
        {
            eventAggregator.Register<DividendPayment>(OnDividendPayment);
            eventAggregator.Register<StandingOrderPayment>(OnStandingOrderPayment);
        }

        private void OnDividendPayment(DividendPayment evt)
        {
            Console.WriteLine($"Dividend paid by {evt.From} to {evt.To} on {evt.PaymentDate} of £{evt.Amount}.");
        }

        private void OnStandingOrderPayment(StandingOrderPayment evt)
        {
            try
            {
                Console.WriteLine($"Standing order paid by {evt.From} to {evt.To} on {GetStandingOrderDate(evt.StartDate)} of £{evt.Amount}.");
            }
            catch (InvalidDateException idex)
            {
                Console.WriteLine(idex.Message);
            }
        }

        private static DateTime GetStandingOrderDate(DateOnly startDate)
        {
            if (DateTime.UtcNow.Ticks < startDate.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.Zero)).Ticks)
                throw new InvalidDateException("Invalid Date: Payment date cannot be before standing order start date!");
            if (DateTime.Now.Day < startDate.Day)
                throw new InvalidDateException("InvalidDate: Payment cannot be made before the standing order month pay day.");
            return DateTime.Now;
        }
    }
}
