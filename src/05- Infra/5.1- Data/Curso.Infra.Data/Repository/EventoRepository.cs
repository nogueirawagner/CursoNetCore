using Curso.Domain.IRepositories;
using Curso.Domain.Models;
using Curso.Infra.Data.Context;

namespace Curso.Infra.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(ContextDb context) 
            : base(context)
        {
        }
    }
}
