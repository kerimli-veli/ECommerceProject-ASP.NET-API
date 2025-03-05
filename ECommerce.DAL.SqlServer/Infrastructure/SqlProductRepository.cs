using Dapper;
using ECommerce.DAL.SqlServer.Context;
using ECommerce.Domain.Entities;
using ECommerce.Repository.Repository;

namespace ECommerce.DAL.SqlServer.Infrastructure;

public class SqlProductRepository(string connectionString, AppDbContext context) : BaseSqlRepository(connectionString), IProductsRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(Product product)
    {
        var sql = @"INSERT INTO Products ( [Id],  [ProductName],[QuantityPerUnit],
                    [UnitPrice],[UnitsInStock],[UnitsOnOrder]  [CreatedBy]) 
                    VALUES (@ProductName, @QuantityperUnit,@UnitPrice @UnitsInStock @UnitsOnOrder @CreatedBy); SELECT SCOPE_IDENTITY()";

        using var conn = OpenConnection();
        var genereatedId = await conn.ExecuteScalarAsync<int>(sql, product);
        product.Id = genereatedId;

    }

    public async Task <bool> Delete(int id , int deletedBy)  
    {
        var checkSql = @"SELECT Id From Products WHERE Id = @id and IsDeleted=0";
        var sql = @"UPDATE Products SET IsDeleted = 1 , 
                DeletedBy = @deletedBy,
                DeletedDate = GETDATE(),
                WHERE Id = @id";

        using var conn = OpenConnection();
        using var transaction = conn.BeginTransaction();
        var CategoryId= await conn.ExecuteScalarAsync<int?>(checkSql, new { id }, transaction); // int yaninda ki sual nullable olada biler olmuyada
            // new id anonim id yaradir
        if (!CategoryId.HasValue)
        
            return false;

            var affectedRows = await conn.ExecuteAsync(sql, new { id, deletedBy }, transaction);
            transaction.Commit();
            return affectedRows > 0;
        
       

    }

    public IQueryable<Product> GetAll()
    {
        return _context.Products.OrderByDescending(x => x.CreatedDate).Where(c => c.IsDeleted == false);
    }

    public async Task<IEnumerable<Product>> GetAllInitalDataAsync()
    {
        var sql = @"SELECT C.[Id] , C.[ProductName] C.[QuantityPerUnit],
                    C.[UnitPrice], C.[UnitsInStock], C.[UnitsOnOrder] 
                      FROM Products AS C 
                       WHERE IsDeleted = 0  ";

        using var conn = OpenConnection();
        return await conn.QueryAsync<Product>(sql , conn);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var sql = @"SELECT C.* 
                   FROM Products AS C 
                    WHERE C.Id = @id AND C.IsDeleted=0";

        using var conn = OpenConnection();
        return await conn.QueryFirstOrDefaultAsync<Product>(sql, new { id });
    }

    public void Update(Product product)
    {
        var sql = @"UPDATE Products SET [ProductName] = @ProductName,
                    [QuantityPerUnit] = @QuantityPerUnit,
                    [UnitPrice] = @UnitPrice,
                    [UnitsInStock] = @UnitsInStock,
                    [UnitsOnOrder] = @UnitsOnOrder,
                    [UpdatedBy] = @UpdatedBy,
                    [UpdatedDate] = GETDATE()
                    WHERE Id = @Id";

        var conn = OpenConnection();
        conn.Query(sql, product);
    }
}
