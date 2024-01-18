namespace JC_Raizen.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Remove(int id);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
    }
}
