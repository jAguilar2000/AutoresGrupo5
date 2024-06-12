using SQLite;

namespace AutoresGrupo5.Models
{
    [Table("Paises")]
    public class Paises
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Pais { get; set; } = string.Empty;
    }
}
