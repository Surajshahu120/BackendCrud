using CrudBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudBackend.UnitWorkPattern
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public UnitOfWork(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public async Task CommitAsync() {
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
