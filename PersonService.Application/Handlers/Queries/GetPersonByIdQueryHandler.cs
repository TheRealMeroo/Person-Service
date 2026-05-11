using MediatR;
using PersonService.Application.Queries;
using PersonService.Domain.Entities;
using PersonService.Domain.Interfaces.Repositories;

namespace PersonService.Application.Handlers.Queries;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person?>
{
    private readonly IReadRepository<Person> _readRepository;

    public GetPersonByIdQueryHandler(IReadRepository<Person> readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken ct)
    {
        return await _readRepository.GetByIdAsync(id: request.Id);
    }
}
