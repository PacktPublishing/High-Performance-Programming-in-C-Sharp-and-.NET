namespace CH12_ResponsiveMAUI.Data
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ICollection<T> Context;

        public BaseRepository(ICollection<T> context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Add(entity);
        }

        public int Count()
        {
            if (Context != null)
                return Context.Count;
            return 0;
        }

        public List<T> Filter(Func<T, bool> query)
        {
            return Context.Where(query).ToList();
        }

        public int FilteredCount(Func<T, bool> query)
        {
            return Context.Where(query).Count();
        }

        public T FirstOrDefault(Func<T, bool> query)
        {
            return Context.Where(query).FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return Context.ToList();
        }

        public T GetById(int id)
        {
            return Context.Where(t => t.Id == id).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            Context.Remove(entity);
        }

        public void Update(T entity)
        {
            T item = Context.FirstOrDefault(t => t.Id == entity.Id);
            int index = Context.ToList().IndexOf(item);
            if (index != -1)
                Context.ToList()[index] = entity;
        }
    }
}
