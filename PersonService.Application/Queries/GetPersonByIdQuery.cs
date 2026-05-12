using MediatR;
using PersonService.Domain.Entities;

namespace PersonService.Application.Queries;

public class GetPersonByIdQuery : IRequest<Person?>
{
    public Guid Id { get; private set; }

    public GetPersonByIdQuery(Guid id)
    {
        Id = id;
    }
}
