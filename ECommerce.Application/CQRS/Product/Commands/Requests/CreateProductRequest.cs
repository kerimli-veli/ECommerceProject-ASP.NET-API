using ECommerce.Application.CQRS.Product.Commands.Responses;
using ECommerce.Application.GlobalResponses;
using ECommerce.Application.GlobalResponses.Generics;
using MediatR;

namespace ECommerce.Application.CQRS.Product.Commands.Requests;

public class CreateProductRequest : IRequest<Result<CreateProductResponse>>
{
    public string ProductName { get; set; }
}
