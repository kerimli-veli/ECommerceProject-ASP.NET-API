using ECommerce.Application.CQRS.Commands.Responses;
using ECommerce.Application.GlobalResponses;
using ECommerce.Application.GlobalResponses.Generics;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.Requests;

public class CreateProductRequest : IRequest<Result<CreateProductResponse>>
{
   public string ProductName { get; set; }
}
