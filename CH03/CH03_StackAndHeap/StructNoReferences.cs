namespace CH03_StackAndHeap
{
    using System;

    internal class StructNoReferences
    {
        public StructNoReferences(
            int id,
            decimal price,
            DateTime purchaseDate
        )
        {
            Id = id;
            Price = price;
            PurchaseDate = purchaseDate;
        }

        public int Id { get; private set; }
        public decimal Price { get; private set; }
        public DateTime PurchaseDate { get; private set; }
    }
}