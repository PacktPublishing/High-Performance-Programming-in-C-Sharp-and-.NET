namespace CH03_StackAndHeap
{
    using System;

    internal class ClassNoReferences
    {
        public ClassNoReferences(
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