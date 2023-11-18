using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet.Models
{
    public class Movie
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name.ru-RU")]
        public string? Name { get; set; }
    }
}
