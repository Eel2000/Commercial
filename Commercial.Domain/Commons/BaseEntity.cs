namespace Commercial.Domain.Commons;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdate { get; set; }
    public Guid UpdateBy { get; set; }
    public Guid CreatedBy { get; set; }
    public bool IsActive { get; set; }
}