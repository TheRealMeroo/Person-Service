using PersonService.Domain.Common;
using PersonService.Domain.ValueObjects;

namespace PersonService.Domain.Entities;

public class Person : BaseEntity
{
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public BirthDate BirthDate { get; private set; }

    #region EF Core ctor

    private Person() : base() { }
    #endregion

    #region Internal ctor

    internal Person(Name firstName,
                    Name lastName,
                    NationalCode nationalCode,
                    BirthDate birthDate)
        : base()
    {
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        BirthDate = birthDate;
    }
    #endregion

    #region Public ctor

    public Person(string firstName, string lastName,
                  string nationalCode, DateTime birthDate)
        : this(new Name(firstName),
               new Name(lastName),
               new NationalCode(nationalCode),
               new BirthDate(birthDate))
    { }

    #endregion

    #region Update

    public void Update(Name firstName, Name lastName, BirthDate birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;

        UpdatedAt = DateTime.UtcNow;
    }
    #endregion

    #region Soft‑Delete

    public void MarkDeleted()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }

    #endregion
}
