using Domain.IRepositories;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AdminService : IAdminService
    {
        private IProductService _productService = null!;
        private readonly IAdminRepository _repository;
        
        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public IProductService ProductService
        {
            get
            {
                if (_productService == null)
                    _productService = new ProductService(_repository);

                return _productService;
            }
        }

    }
}
