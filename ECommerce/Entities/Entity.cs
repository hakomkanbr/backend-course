using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Enitites;

public abstract class Entity
{
    public int Id { get; set; }
}

public interface ILog
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
