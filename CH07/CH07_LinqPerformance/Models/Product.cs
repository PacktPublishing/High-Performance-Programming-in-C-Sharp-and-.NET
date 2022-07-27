namespace CH07_LinqPerformance.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product() { }

        public Product(int id)
        {
            Id = id;
            Name = $"Item {Id} Name";
            Description = $"Item {Id} description.";
        }

        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}";
        }
    }
}
