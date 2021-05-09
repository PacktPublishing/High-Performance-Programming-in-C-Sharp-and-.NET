namespace CH01_Records
{
    public record Product
    {
        readonly string Name;
        readonly string Description;

        public Product(string name, string description) 
            => (Name, Description) = (name, description);

        public void Deconstruct(out string name, out string description) 
            => (name, description) = (Name, Description);
    }
}
