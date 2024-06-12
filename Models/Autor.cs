using SQLite;

namespace AutoresGrupo5.Models
{
    [Table("Autor")]
    public class Autor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombres { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Pais { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
    }
}
