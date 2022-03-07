namespace CH13_EventSourcing.BankApp
{
    internal class StandingOrderPayment : IEvent
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateOnly StartDate { get; set; }
        public decimal Amount { get; set; }

    }
}
