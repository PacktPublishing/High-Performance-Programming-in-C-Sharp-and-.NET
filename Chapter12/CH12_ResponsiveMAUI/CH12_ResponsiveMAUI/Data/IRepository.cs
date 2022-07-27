namespace CH12_ResponsiveMAUI.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        T FirstOrDefault(Func<T, bool> query);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        List<T> GetAll();
        List<T> Filter(Func<T, bool> query);
        int Count();
        int FilteredCount(Func<T, bool> query);
    }
}
