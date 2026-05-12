using MediatR;
using PersonService.Domain.Entities;

namespace PersonService.Application.Commands;

public class CreatePersonCommand : IRequest<Person>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalCode { get; private set; }
    public DateTime BirthDate { get; private set; }

    public CreatePersonCommand(string firstName, string lastName, string nationalCode, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        BirthDate = birthDate;
    }

}
