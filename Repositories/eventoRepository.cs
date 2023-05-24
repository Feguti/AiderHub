using AiderHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace AiderHub.Repositories
{
    public class EventoRepository
    {
        private readonly ApplicationDbContext _context;

        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Evento> ObterEventos()
        {
            return _context.Eventos.ToList();
        }
    }
}