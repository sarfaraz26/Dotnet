using Product.Core.Entities;

namespace Product.Core.IRepositories
{
    public interface IDeparmentRepository
    {
        Task<int> CreateDepartment(Department department);
    }
}
