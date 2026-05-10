using PersonService.Domain.ValueObjects;

namespace PersonService.Domain.Entities;

public class Person
{
    public Guid Id { get; private set; }
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public BirthDate BirthDate { get; private set; }

    private Person() { }

    internal Person(Guid id, Name firstName, Name lastName, NationalCode nationalCode, BirthDate birthDate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        BirthDate = birthDate;
    }

    public Person(string firstName, string lastName, string nationalCode, DateTime birthDate) :
        this(Guid.NewGuid(), new Name(firstName), new Name(lastName), new NationalCode(nationalCode), new BirthDate(birthDate))
    { }
}