namespace NewCrud.Request
{
    public class GetEventoRequest
    {
        public DateTime DataInicioEvento { get; set; }
        public DateTime DataFimEvento { get; set; }
        public string? Descricao { get; set; }
        public string? Tema { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
