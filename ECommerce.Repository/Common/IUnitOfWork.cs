using ECommerce.Repository.Repository;

namespace ECommerce.Repository.Common;

public class IUnitOfWork
{
    public IProductsRepository ProductRepository { get; }
    public ICustomersRepository CustomersRepository { get; }

    

}
