using Microsoft.AspNetCore.Mvc;
using NewCrud.Models;
using NewCrud.Request;
using NewCrud.Response;

namespace NewCrud.Services.Interfaces
{
    public interface IEventoService
    {
        Task<GetEventoResponse> GetEventoAsync(GetEventoRequest request);
        Task<Evento> PostEventoAsync(EventoRequest request);
        Task<Evento> PatchEventoAsync(Evento request);
        Task<IActionResult> DeleteEventoAsync(int idEvento);
    }
}
