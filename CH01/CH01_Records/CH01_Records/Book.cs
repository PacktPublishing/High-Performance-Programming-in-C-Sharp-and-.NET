namespace CH01_Records
{
    internal record Book : Publisher
    {
        public string Title { get; init; }
        public string Author { get; init; }
    }
}
