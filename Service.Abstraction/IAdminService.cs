namespace Service.Abstraction
{
    public interface IAdminService
    {
        IProductService ProductService { get; }
    }
}
