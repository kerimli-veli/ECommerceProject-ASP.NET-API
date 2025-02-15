using ECommerce.Domain.Entities;

namespace ECommerce.Repository.Repository;

public interface ICustomersRepository
{
    Task AddAsync(Customers customers);
    void Update(Customers customers);
    Task <bool> Delete(string customerId, int deletedBy);
    IQueryable<Customers> GetAll();
    Task<Customers> GetByIdAsync(string id);
    Task<IEnumerable<Customers>> GetAllInitalDataAsync();
}
