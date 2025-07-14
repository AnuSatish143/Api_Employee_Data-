using Microsoft.EntityFrameworkCore;
using WebApiCoreCruds1.Interfaces;
using WebApiCoreCruds1.Models;

namespace WebApiCoreCruds1.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EmployeesDbContext _context;
        public EmployeesRepository(EmployeesDbContext context)
        {
            _context = context;
        }
        public async Task<Employee?> AddEmployeeAsync(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<bool> DeleteEmployeeAsync(long id)
        {
            var product = await _context.Employees.FindAsync(id);
            if (product == null) return false;

            _context.Employees.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();

        }

        public async Task<Employee?> GetEmployeeByIdAsync(long id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee?> UpdateEmployeeAsync(Employee emp)
        {
            var existing = await _context.Employees.FindAsync(emp.Id);
            if (existing == null) return null;

            existing.Name = emp.Name;
            existing.Age = emp.Age;
            existing.City = emp.City;
            existing.Qualification = emp.Qualification;
            existing.Address = emp.Address;
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
