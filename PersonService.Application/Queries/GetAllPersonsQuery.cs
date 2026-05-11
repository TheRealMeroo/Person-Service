using MediatR;
using PersonService.Domain.Entities;

namespace PersonService.Application.Queries;

public class GetAllPersonsQuery : IRequest<IReadOnlyList<Person>>
{
}
