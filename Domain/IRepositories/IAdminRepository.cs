
namespace Domain.IRepositories
{
    public interface IAdminRepository
    {
        IProductRepository ProductRepository { get; }
    }
}
