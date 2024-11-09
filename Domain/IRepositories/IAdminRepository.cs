
namespace Domain.IRepositories
{
    /// <summary>
    /// Encapsulate the Repositories
    /// </summary>
    public interface IAdminRepository
    {
        IProductRepository ProductRepository { get; }

        public Task<int> SaveChanges();
    }
}
