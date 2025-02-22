using ECommerce.Application.CQRS.Commands.Requests;
using ECommerce.Application.CQRS.Commands.Responses;
using ECommerce.Application.GlobalResponses.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject_ASP.NET_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(ISender sender) : ControllerBase
{
    private readonly ISender sender = sender;



    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        Result<CreateCustomerResponse> response = await sender.Send(request);
        if (response.IsSuccess)
        {
            return Ok(response.Data);
        }
        return BadRequest(response.Errors);
    }
}
