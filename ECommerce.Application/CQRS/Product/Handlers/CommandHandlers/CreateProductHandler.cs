using ECommerce.Application.CQRS.Product.Commands.Requests;
using ECommerce.Application.CQRS.Product.Commands.Responses;
using ECommerce.Application.GlobalResponses.Generics;
using ECommerce.Domain.Entities;
using ECommerce.Repository.Common;
using MediatR;

namespace ECommerce.Application.CQRS.Product.Handlers.CommandHandlers;

public class CreateProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateProductRequest, Result<CreateProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        ECommerce.Domain.Entities.Product product = new()
        {
            ProductName = request.ProductName
        };


        if (string.IsNullOrWhiteSpace(request.ProductName))
        {
            return new Result<CreateProductResponse>
            {
                Data = null,
                Errors = ["Product name is required"],
                IsSuccess = false
            };
        }

        await _unitOfWork.ProductRepository.AddAsync(product);


        CreateProductResponse response = new()
        {
            
            ProductName = request.ProductName
        };

        return new Result<CreateProductResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}

