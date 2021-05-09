namespace CH01_PatternMatching
{
    internal record Product
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal UnitPrice { get; init; }
    }
}