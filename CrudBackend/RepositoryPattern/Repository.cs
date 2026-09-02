using CrudBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
            _dbSet = _employeeDbContext.Set<T>();
        }
        public async Task<T> AddData(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public async Task<T> UpdateData(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
        public async Task<List<T>> BulkDataAdd(List<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
            return entity;
        }
        public async Task DeleteData(T id)
        {
             _dbSet.Remove(id);
        }
        public async Task<IEnumerable<T>> GetAllData()
        {
            return await _dbSet.ToListAsync();
        } 
        public async Task<T> GetDataById(int id)
        {
            return await _dbSet.FindAsync(id); ;
        }
        public IQueryable<T> GetAllQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }
}
