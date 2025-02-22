using ECommerce.Application.CQRS.Commands.Requests;
using ECommerce.Application.CQRS.Commands.Responses;
using ECommerce.Application.GlobalResponses.Generics;
using ECommerce.Domain.Entities;
using ECommerce.Repository.Common;
using MediatR;

namespace ECommerce.Application.CQRS.Handlers.CommandHandlers;

public class CreateProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateProductRequest, Result<CreateProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        Product product = new()
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

        await _unitOfWork.ProductsRepostory.AddAsync(product);

        CreateProductResponse response = new()
        {
            Id = product.Id,
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

