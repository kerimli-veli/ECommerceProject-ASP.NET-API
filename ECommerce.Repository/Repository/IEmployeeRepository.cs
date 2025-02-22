using ECommerce.Domain.Entities;

namespace ECommerce.Repository.Repository;

public interface IEmployeeRepository
{
    Task Register(Employee employee);
    void Update(Employee employee);
    Task Delete(int id);
    IQueryable<Employee> GetAll();
    Task<Employee> GetByIdAsync(int id);

    Task<Employee> GetByLastNameAsync(string lastName);
}
