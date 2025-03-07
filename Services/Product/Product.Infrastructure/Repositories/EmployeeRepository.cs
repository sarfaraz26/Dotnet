using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Core.Specs;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProductContext _context;

        public EmployeeRepository(ProductContext context)
        {
            _context = context;
        }


        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<int> DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            int response = await _context.SaveChangesAsync();
            return response;
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            var employee = await  (from e in _context.Employees
                        join d in _context.Departments
                        on e.DepartmentId equals d.Id
                        where e.Id == id
                        select new Employee()
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Email = e.Email,
                            Resigned = e.Resigned,
                            DepartmentId = e.DepartmentId,
                            Department = d
                        }).SingleOrDefaultAsync();

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees(Pagination pagination)
        {
            var employees = await _context.Employees
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return employees;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            int response = await _context.SaveChangesAsync();
            return response;
        }
    }
}
