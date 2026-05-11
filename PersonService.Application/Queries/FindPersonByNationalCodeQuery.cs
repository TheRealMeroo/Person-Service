using MediatR;
using PersonService.Domain.Entities;

namespace PersonService.Application.Queries;

public class FindPersonByNationalCodeQuery : IRequest<Person?>
{
    public string NationalCode { get; set; }
}
