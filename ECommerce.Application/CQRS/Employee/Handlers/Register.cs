using ECommerce.Application.CQRS.Employee.ResponsesDto;
using ECommerce.Application.GlobalResponses.Generics;
using ECommerce.Repository.Repository;
using MediatR;

namespace ECommerce.Application.CQRS.Employee.Handlers;

public class Register
{
    public class Command : IRequest<Result<RegisterDto>>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
    }
    public class Handler : IRequestHandler<Command, Result<RegisterDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public Handler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<Result<RegisterDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Title = request.Title
            };
            await _employeeRepository.AddAsync(employee);
            return Result<RegisterDto>.Success(_mapper.Map<RegisterDto>(employee));
        }
    }
}
