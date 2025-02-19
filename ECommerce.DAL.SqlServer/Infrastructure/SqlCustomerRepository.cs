using Dapper;
using ECommerce.DAL.SqlServer.Context;
using ECommerce.Domain.Entities;
using ECommerce.Repository.Repository;

namespace ECommerce.DAL.SqlServer.Infrastructure;

public class SqlCustomerRepository : BaseSqlRepository, ICustomersRepository
{

    private readonly AppDbContext _context;
    public SqlCustomerRepository(string connectionString, AppDbContext context) : base(connectionString)
    {
        _context = context;
    }

    public async Task AddAsync(Customers customer)
    {
        var sql = @"INSERT INTO Customers ([CustomerId], [CompanyName], [ContactName],
                    [ContactTitle], [Address], [City], [Region], [PostalCode],
                    [Country], [Phone], [Fax])
                    VALUES (@CustomerId, @CompanyName, @ContactName, @ContactTitle,
                    @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax); SELECT SCOPE_IDENTITY() ";

        using var conn = OpenConnection();
        var genereatedId = await conn.ExecuteScalarAsync<int>(sql , customer );
        customer.Id = genereatedId;
    }

    public async Task<bool> Delete(string customerId, int deletedBy)
    {
        var checkSql = "SELECT CustomerId FROM Customers WHERE CustomerId = @customerId AND IsDeleted = 0";
        var sql = @"UPDATE Customers SET IsDeleted = 1, 
                    DeletedBy = @deletedBy,
                    DeletedDate = GETDATE()
                    WHERE CustomerId = @customerId";

        using var conn = OpenConnection();
        using var transaction = conn.BeginTransaction();
        var existingCustomer = await conn.ExecuteScalarAsync<string>(checkSql, new { customerId }, transaction);

        if (existingCustomer == null)
            return false;

        var affectedRows = await conn.ExecuteAsync(sql, new { customerId, deletedBy }, transaction);
        transaction.Commit();
        return affectedRows > 0;
    }

    public IQueryable<Customers> GetAll()
    {
        return _context.Customers.OrderByDescending(x => x.CompanyName).Where(c => c.IsDeleted == false);
    }

    public async Task<IEnumerable<Customers>> GetAllInitalDataAsync()
    {
        var sql = @"SELECT C.[CustomerId], C.[CompanyName], C.[ContactName],
                    C.[ContactTitle], C.[Address], C.[City], C.[Region],
                    C.[PostalCode], C.[Country], C.[Phone], C.[Fax]
                    FROM Customers AS C WHERE IsDeleted = 0";

        using var conn = OpenConnection();
        return await conn.QueryAsync<Customers>(sql, conn);
    }

    

    public async Task<Customers> GetByIdAsync(string customerId)
    {
        var sql = "SELECT * FROM Customers WHERE CustomerId = @customerId AND IsDeleted = 0";

        using var conn = OpenConnection();
        return await conn.QueryFirstOrDefaultAsync<Customers>(sql, new { customerId });
    }

    public void Update(Customers customer)
    {
        var sql = @"UPDATE Customers SET CompanyName = @CompanyName,
                    ContactName = @ContactName,
                    ContactTitle = @ContactTitle,
                    Address = @Address,
                    City = @City,
                    Region = @Region,
                    PostalCode = @PostalCode,
                    Country = @Country,
                    Phone = @Phone,
                    Fax = @Fax,
                    UpdatedBy = @UpdatedBy,
                    UpdatedDate = GETDATE()
                    WHERE CustomerId = @CustomerId";

        using var conn = OpenConnection();
        conn.Execute(sql, customer);
    }
}

