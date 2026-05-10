using System.ComponentModel.DataAnnotations;

namespace PersonService.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; protected set; }

    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public bool IsDeleted { get; protected set; } = false;

    [Timestamp]
    public byte[] RowVersion { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
}