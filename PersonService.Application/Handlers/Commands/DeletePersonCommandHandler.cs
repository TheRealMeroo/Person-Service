using MediatR;
using PersonService.Application.Commands;
using PersonService.Domain.Entities;
using PersonService.Domain.Interfaces.Repositories;

namespace PersonService.Application.Handlers.Commands;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IWriteRepository<Person> _writeRepository;

    public DeletePersonCommandHandler(IWriteRepository<Person> writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        await _writeRepository.DeleteAsync(id: request.Id);
    }
}
