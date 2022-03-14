using System.ComponentModel.DataAnnotations.Schema;

namespace src.Entities;

public class BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    [Column("id")]
    public virtual int Id { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    [Column("created_at")]
    public virtual DateTime CreatedAt { get; set; } 

    /// <summary>
    /// Дата обновления
    /// </summary>
    [Column("updated_at")]
    public virtual DateTime UpdatedAt { get; set; }
}