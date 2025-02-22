using ECommerce.Application.CQRS.Commands.Requests;
using ECommerce.Application.CQRS.Commands.Responses;
using ECommerce.Application.GlobalResponses.Generics;
using ECommerce.Domain.Entities;
using ECommerce.Repository.Common;
using MediatR;

namespace ECommerce.Application.CQRS.Handlers.CommandHandlers;

public class CreateCustomerHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerRequest, Result<CreateCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        Customers customer = new()
        {
            CompanyName = request.CompanyName
        };

        if(string.IsNullOrWhiteSpace(request.CompanyName))
        {
            return new Result<CreateCustomerResponse>
            {
                Data = null,
                Errors = ["Customer name is required"],
                IsSuccess = false
            };
        }

       await _unitOfWork.CustomersRepository.AddAsync(customer);

       CreateCustomerResponse response = new()
       {
           CustomerId = customer.CustomerId,
           CompanyName = request.CompanyName
       };

        return new Result<CreateCustomerResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };

    }
}
