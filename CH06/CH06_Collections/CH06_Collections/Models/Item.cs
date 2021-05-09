namespace CH06_Collections.Models
{
    internal class Item
    {
        private int _id;
        private string _name;
        private string _description;

        public Item(int id)
        {
            _id = id;
            _name = $"Item {_id} Name";
            _description = $"Item {_id} description.";
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
    }
}
