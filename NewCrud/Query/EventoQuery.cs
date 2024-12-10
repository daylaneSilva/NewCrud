using NewCrud.Models;

namespace NewCrud.Query
{
    public static class EventoQuery
    {
        public static IQueryable<Evento> FiltrarPorDataEvento(this IQueryable<Evento> query, DateTime dataInicio, DateTime dataFim)
        {
            if (dataInicio != DateTime.MinValue && dataFim == DateTime.MinValue)
                query.Where(x => x.DataEvento.Date == dataInicio.Date);

            if (dataInicio != DateTime.MinValue && dataFim != DateTime.MinValue)
                query.Where(x => x.DataEvento.Date >= dataInicio.Date && x.DataEvento.Date <= dataFim.Date);

            return query;
        }
        public static IQueryable<Evento> FiltrarPorDataRegistro(this IQueryable<Evento> query, DateTime dataRegistro)
        {
            if (dataRegistro != DateTime.MinValue)
                query.Where(x => x.DataInclusao.Date >= dataRegistro.Date);

            return query;
        }
        public static IQueryable<Evento> FiltrarPorTema(this IQueryable<Evento> query, string Tema)
        {
            if (!string.IsNullOrEmpty(Tema))
                return query.Where(x => x.Tema == Tema.ToUpper());

            return query;
        }
        public static IQueryable<Evento> FiltrarPorDescricao(this IQueryable<Evento> query, string descricao)
        {
            if (!string.IsNullOrEmpty(descricao))
                return query.Where(x => x.Descricao.Contains(descricao));

            return query;
        }
    }
}
