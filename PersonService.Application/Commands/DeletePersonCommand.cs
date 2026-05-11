using MediatR;

namespace PersonService.Application.Commands;

public class DeletePersonCommand: IRequest
{
    public Guid Id { get; set; }
}
