namespace CH01_PatternMatching
{
    internal record OrderItem : Product
    {
        public int QuantityOrdered { get; init; }
    }
}