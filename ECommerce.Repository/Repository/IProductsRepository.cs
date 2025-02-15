using ECommerce.Domain.Entities;

namespace ECommerce.Repository.Repository;

public interface IProductsRepository
{
    Task AddAsync(Product product);
    void Update(Product product);
     Task <bool> Delete(int id , int deletedBy );
    IQueryable<Product> GetAll();
    Task<Product> GetByIdAsync(int id);

    Task<IEnumerable<Product>> GetAllInitalDataAsync();
}
