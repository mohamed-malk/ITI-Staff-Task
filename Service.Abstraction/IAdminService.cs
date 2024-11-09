namespace Service.Abstraction
{
    /// <summary>
    /// Encapsulate the Services
    /// </summary>
    public interface IAdminService
    {
        IProductService ProductService { get; }
    }
}
