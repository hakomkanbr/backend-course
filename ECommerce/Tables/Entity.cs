namespace ECommerce.Tables;

public abstract class Entity
{
    public int Id { get; set; }
}

public interface ILog
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
