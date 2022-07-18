using CH12_ResponsiveMAUI.Models;

namespace CH12_ResponsiveMAUI.Data
{
    internal class PeopleRepository : BaseRepository<Person>
    {
        public PeopleRepository(ICollection<Person> context) : base(context)
        {
        }
    }
}
