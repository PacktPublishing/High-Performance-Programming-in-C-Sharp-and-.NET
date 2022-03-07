namespace CH13_EventSourcing.BankApp
{
    internal class DividendPayment : IEvent
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime PaymentDate { get; set; }
        public Decimal Amount { get; set; }
    }
}
