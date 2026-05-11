using MediatR;
using PersonService.Application.Queries;
using PersonService.Domain.Entities;
using PersonService.Domain.Interfaces.Repositories;

namespace PersonService.Application.Handlers.Queries;

public class FindPersonByNationalCodeQueryHandler : IRequestHandler<FindPersonByNationalCodeQuery, Person?>
{
    private readonly IReadRepository<Person> _readRepository;

    public FindPersonByNationalCodeQueryHandler(IReadRepository<Person> readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<Person?> Handle(FindPersonByNationalCodeQuery request, CancellationToken ct)
    {
        return await _readRepository.FindByNationalCodeAsync(nationalCode: request.NationalCode, ct);
    }
}
