using WebApiCoreCruds1.Models;

namespace WebApiCoreCruds1.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(long id);
        Task<Employee?> AddEmployeeAsync(Employee emp);
        Task<Employee?> UpdateEmployeeAsync(Employee emp);
        Task<bool> DeleteEmployeeAsync(long id);
    }
}
