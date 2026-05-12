using MediatR;
using PersonService.Application.Commands;
using PersonService.Domain.Entities;
using PersonService.Domain.Factories;
using PersonService.Domain.Interfaces.Repositories;

namespace PersonService.Application.Handlers.Commands;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Person?>
{
    private readonly IWriteRepository<Person> _writeRepository;

    public UpdatePersonCommandHandler(IWriteRepository<Person> writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task<Person?> Handle(UpdatePersonCommand request, CancellationToken ct)
    {
        var entity = PersonFactory.Create(
            firstName: request.FirstName,
            lastName: request.LastName,
            nationalCode: request.NationalCode,
            birthDate: request.BirthDate
            );

        return await _writeRepository.UpdateAsync(entity, ct);
    }
}
