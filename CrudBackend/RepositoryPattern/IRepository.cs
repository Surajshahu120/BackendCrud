using CrudBackend.Data;

namespace CrudBackend.RepositoryPattern
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddData(T entity);
        Task<T> UpdateData(T entity);
        Task DeleteData(T id);
        Task<IEnumerable<T>> GetAllData();
        Task<T> GetDataById(int id);
        IQueryable<T> GetAllQueryable();

    }
}
