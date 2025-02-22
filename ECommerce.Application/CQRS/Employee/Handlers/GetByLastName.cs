using ECommerce.Application.CQRS.Employee.ResponsesDto;
using ECommerce.Application.GlobalResponses.Generics;
using ECommerce.Common.Exceptions;
using ECommerce.Repository.Common;
using ECommerce.Repository.Repository;
using MediatR;

namespace ECommerce.Application.CQRS.Employee.Handlers;

public class GetByLastName
{
   public class Query : IRequest<List<GetByLastNameDto>>
    {
        public string LastName { get; set; }
    }

    public class Handler : IRequestHandler<Query, List<GetByLastNameDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
       

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
        public async Task<List<GetByLastNameDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var currentEmployee = await _unitOfWork.EmployeeRepository.GetByLastNameAsync(request.LastName);

            if (currentEmployee == null)
            {
                return new Result<GetByLastNameDto>() {Errors = ["User not found"] , IsSuccess = false };
            }

            GetByLastName getByLastName = new()
            {
                Id = currentEmployee.Id,
                LastName = currentEmployee.LastName,
                FirstName = currentEmployee.FirstName,
                Title = currentEmployee.Title
            };

            return new Result<GetByLastNameDto>() { Data = getByLastName, Errors = [], IsSuccess = true };
        }
    }
}
