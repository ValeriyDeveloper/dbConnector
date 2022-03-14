using System.ComponentModel.DataAnnotations.Schema;

namespace src.Entities;

public class Client : BaseEntity
{
    /// <summary>
    /// Масса клиента
    /// </summary>
    [Column("mass")]
    public double Mass { get; set; }

    /// <summary>
    /// Уникальный идентификатор аккаунта
    /// </summary>
    [Column("account_id")]
    public int AccountId { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор группы
    /// </summary>
    [Column("group_id")]
    public int? GroupId { get; set; }
}