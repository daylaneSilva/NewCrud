using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCrud.Data;
using NewCrud.Models;
using NewCrud.Query;
using NewCrud.Request;
using NewCrud.Response;
using NewCrud.Services.Interfaces;

namespace NewCrud.Services
{
    public class EventoService : IEventoService
    {
        private readonly AppDbContext _appDbContext;
        public EventoService(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<IActionResult> DeleteEventoAsync(int idEvento)
        {
            var evento = _appDbContext.eventos.FirstOrDefault(x => x.Id == idEvento);
            if (evento != null)
            {
                _appDbContext.eventos.Remove(evento);
                 await _appDbContext.SaveChangesAsync();
                return await Task.FromResult(new OkObjectResult(new { message = "Evento deletado com sucesso." }));
            }
            else
                return await Task.FromResult(new BadRequestObjectResult(new { message = $"Evento não encontrado." }));

        }

        public async Task<GetEventoResponse> GetEventoAsync(GetEventoRequest request)
        {
            var totalRegistros = await _appDbContext.eventos.CountAsync();
            var tabelaEventos = await _appDbContext.eventos.AsNoTracking()
                                                           .FiltrarPorDataEvento(request.DataInicioEvento, request.DataFimEvento)
                                                           .FiltrarPorDataRegistro(request.DataInclusao)
                                                           .FiltrarPorTema(request.Tema)
                                                           .FiltrarPorDescricao(request.Descricao)
                                                           .Select(x => new Evento
                                                           {
                                                               Id = x.Id,
                                                               Tema = x.Tema,
                                                               Descricao = x.Descricao,
                                                               DataInclusao = x.DataInclusao,
                                                               DataEvento = x.DataEvento,
                                                           }).ToListAsync();

            return new GetEventoResponse
            {
                listaEvento = tabelaEventos,
                totalRegistros = totalRegistros,
            };
        }

        public async Task<Evento> PatchEventoAsync(Evento request)
        {
            var registroEvento = _appDbContext.eventos.Update(request);
            await _appDbContext.SaveChangesAsync();

            return registroEvento.Entity;
        }

        public async Task<Evento> PostEventoAsync(EventoRequest request)
        {
            var entity = new Evento
            {
                Tema = request.Tema.ToUpper(),
                Descricao = request.Descricao,
                DataInclusao = DateTime.Now,
                DataEvento = request.DataEvento,
            };
           
            await _appDbContext.eventos.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
