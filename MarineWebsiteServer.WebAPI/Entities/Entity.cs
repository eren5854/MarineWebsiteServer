namespace MarineWebsiteServer.WebAPI.Entities;

public class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string? UpdatdBy { get; set; }
    public DateTime? UpdatdDate { get; set; }
}
