using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repositories
{
    public class DepartmentRepository : IDeparmentRepository
    {
        private readonly ProductContext _context;

        public DepartmentRepository(ProductContext context)
        {
            _context = context;
        }


        public async Task<int> CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            int response = await _context.SaveChangesAsync();
            return response;
        }
    }
}
