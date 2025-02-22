namespace ECommerce.Application.CQRS.Employee.ResponsesDto;

public class GetByLastNameDto
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
}
