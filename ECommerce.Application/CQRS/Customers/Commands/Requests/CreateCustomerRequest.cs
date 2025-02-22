using ECommerce.Application.CQRS.Customers.Commands.Responses;
using ECommerce.Application.GlobalResponses.Generics;
using MediatR;

namespace ECommerce.Application.CQRS.Customers.Commands.Requests;

public class CreateCustomerRequest : IRequest<Result<CreateCustomerResponse>>
{

    public string CompanyName { get; set; }
}
