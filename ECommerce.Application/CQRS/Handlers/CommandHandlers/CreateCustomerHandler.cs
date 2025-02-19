using ECommerce.Application.CQRS.Commands.Requests;
using ECommerce.Application.CQRS.Commands.Responses;
using ECommerce.Application.GlobalResponses.Generics;
using MediatR;

namespace ECommerce.Application.CQRS.Handlers.CommandHandlers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, Result<CreateCustomerResponse>>
{
    public Task<Result<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
