using NewCrud.Models;

namespace NewCrud.Response
{
    public class GetEventoResponse
    {
        public List<Evento> listaEvento {  get; set; }
        public int totalRegistros { get; set; }
    }
}
