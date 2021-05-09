namespace CH06_Collections.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        private int _id;
        private string _name;
        private string _description;

        public Product() { }

        public Product(int id)
        {
            _id = id;
            _name = $"Item {_id} Name";
            _description = $"Item {_id} description.";
        }

        [Key]
        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }

        public override string ToString()
        {
            return $"Id: {_id}, Name: {_name}, Description: {_description}";
        }
    }
}
