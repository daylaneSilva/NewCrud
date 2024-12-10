using System.ComponentModel.DataAnnotations;

namespace NewCrud.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataEvento { get; set; }
        public string? Descricao { get; set; }
        public string? Tema { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
