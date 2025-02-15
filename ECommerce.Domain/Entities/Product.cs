using ECommerce.Domain.BaseEntities;

namespace ECommerce.Domain.Entities;

public class Product : BaseEntity
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int SupplierId { get; set; }
    public int CategoryId { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public short UnitsOnOrder { get; set; }
    public short ReorderLevel { get; set; }
    public bool Discontinued { get; set; }

}
