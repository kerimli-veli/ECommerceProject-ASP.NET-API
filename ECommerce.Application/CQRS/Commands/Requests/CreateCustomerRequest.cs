﻿using ECommerce.Application.CQRS.Commands.Responses;
using ECommerce.Application.GlobalResponses.Generics;
using MediatR;

namespace ECommerce.Application.CQRS.Commands.Requests;

public class CreateCustomerRequest : IRequest<Result<CreateCustomerResponse>>
{
    
    public string CompanyName { get; set; }
}
