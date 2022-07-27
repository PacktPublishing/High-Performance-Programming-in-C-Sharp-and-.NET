using CH12_ResponsiveMAUI.Models;

namespace CH12_ResponsiveMAUI.ViewModels
{
    public class PeopleViewModel : ViewModelBase<Person>
    {
        public PeopleViewModel()
        {
            SeedPeopleRepository();
        }

        private void SeedPeopleRepository()
        {
            Entities.Add(new Person { Id = 1, FirstName = "Person", LastName = "One", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 2, FirstName = "Person", LastName = "Two", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 3, FirstName = "Person", LastName = "Three", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 4, FirstName = "Person", LastName = "Four", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 5, FirstName = "Person", LastName = "Five", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 6, FirstName = "Person", LastName = "Six", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 7, FirstName = "Person", LastName = "Seven", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 8, FirstName = "Person", LastName = "Eight", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 9, FirstName = "Person", LastName = "Nine", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 10, FirstName = "Person", LastName = "Ten", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 11, FirstName = "Person", LastName = "Eleven", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 12, FirstName = "Person", LastName = "Twelve", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 13, FirstName = "Person", LastName = "Thirteen", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 14, FirstName = "Person", LastName = "Fourteen", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 15, FirstName = "Person", LastName = "Fifteen", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 16, FirstName = "Person", LastName = "Sixteen", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 17, FirstName = "Person", LastName = "Seventeen", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 18, FirstName = "Person", LastName = "Eighteen", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 19, FirstName = "Person", LastName = "Ninetenn", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            Entities.Add(new Person { Id = 20, FirstName = "Person", LastName = "Twenty", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
        }
    }
}
