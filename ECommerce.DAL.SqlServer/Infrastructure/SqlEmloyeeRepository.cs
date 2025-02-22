using ECommerce.DAL.SqlServer.Context;
using ECommerce.Domain.Entities;
using ECommerce.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DAL.SqlServer.Infrastructure;

public class SqlEmloyeeRepository(AppDbContext context) : IEmployeeRepository
{
    private readonly AppDbContext _context = context;

    public async Task Delete(int id)
    {
         var employee = await _context.Employees.FirstOrDefault(e => e.Id == id);
         employee.IsDeleted = true;
         employee.DeletedDate = DateTime.Now;
    }

    public IQueryable<Employee> GetAll()
    {
        return _context.Employees;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return  _context.Employees.FirstOrDefault(e => e.Id == id);
    }

    public async Task<Employee> GetByLastNameAsync(string lastName)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.LastName == lastName);
    }

    public async Task Register(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
    }

    public void Update(Employee employee)
    {
        employee.UpdatedDate = DateTime.Now;
        _context.Employees.Update(employee);
    }
}
