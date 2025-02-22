namespace ECommerce.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(Type type, int id) : base($"{type.Name} with id {id} not found")
    {
    }
}
