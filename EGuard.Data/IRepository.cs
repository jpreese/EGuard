namespace EGuard.Data
{
    public interface IRepository<T>
    {
        T Get(T model);
        void Delete(T model);
        void Add(T model);
    }
}
