using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private IProductRepository _productRepository;

        public AdminRepository()
        {
            _productRepository = new ProductRepository();
        }

        public IProductRepository ProductRepository => _productRepository;
    }
}
