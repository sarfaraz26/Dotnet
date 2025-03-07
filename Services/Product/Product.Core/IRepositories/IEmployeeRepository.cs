using Product.Core.Entities;
using Product.Core.Specs;

namespace Product.Core.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees(Pagination pagination);
        Task<Employee> GetEmployeeById(Guid id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(Employee employee);
    }
}
