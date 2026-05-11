using MediatR;
using PersonService.Domain.Entities;

namespace PersonService.Application.Commands;

public class UpdatePersonCommand : IRequest<Person?>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public DateTime BirthDate { get; set; }
}
