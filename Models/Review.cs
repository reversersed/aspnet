using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet.Models
{
    public sealed class Review
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("text")]
        public string? Text { get; set; }
        [Column("rating")]
        public float Rating { get; set; }
        [Column("movie")]
        public int MovieId { get; set; }
    }
}
