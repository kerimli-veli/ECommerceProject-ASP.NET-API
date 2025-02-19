using ECommerce.Application.GlobalResponses.Generics;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.Requests;

public class CreateCustomerRequest : IRequest<Result<CreateCustomersResponse>>
{
    public string Name { get; set; }
}
