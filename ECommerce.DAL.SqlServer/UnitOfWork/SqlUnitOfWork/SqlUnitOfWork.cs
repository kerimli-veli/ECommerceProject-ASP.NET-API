using ECommerce.DAL.SqlServer.Context;
using ECommerce.DAL.SqlServer.Infrastructure;
using ECommerce.Repository.Common;
using ECommerce.Repository.Repository;

namespace ECommerce.DAL.SqlServer.UnitOfWork.SqlUnitOfWork;

public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{
    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _context = context;

    public SqlProductRepository _categoryRepository;
    public SqlCustomerRepository _customerRepository;

    public IProductsRepository ProductsRepostory =>_categoryRepository ??  new SqlProductRepository(_connectionString, _context);
    public ICustomersRepository CustomersRepository => _customerRepository ?? new SqlCustomerRepository(_connectionString, _context);
}
