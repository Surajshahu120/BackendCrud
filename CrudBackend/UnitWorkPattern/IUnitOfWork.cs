namespace CrudBackend.UnitWorkPattern
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
