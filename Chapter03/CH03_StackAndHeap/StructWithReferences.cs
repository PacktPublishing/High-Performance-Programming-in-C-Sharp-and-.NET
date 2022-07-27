namespace CH03_StackAndHeap
{
    using System;
    using System.Collections.Generic;

    internal struct StructWithReferences
    {
        public StructWithReferences(
            int id,
            string name,
            decimal price,
            DateTime purchaseDate,
            Dictionary<string, string> keyValueData
        )
        {
            Id = id;
            Name = name;
            Price = price;
            PurchaseDate = purchaseDate;
            KeyValueData = keyValueData;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public Dictionary<string, string> KeyValueData { get; private set; }
    }
}
