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
        private readonly ApplicationContext _context;
        private IProductRepository _productRepository;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
            _productRepository = new ProductRepository(_context);
        }

        public IProductRepository ProductRepository => _productRepository;


        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
