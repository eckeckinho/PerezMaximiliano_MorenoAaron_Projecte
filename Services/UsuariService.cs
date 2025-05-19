using Data;
using Entitats.AuthClasses;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UsuariService : IUsuariService
    {
        private readonly DBContext _context;

        public UsuariService(DBContext context)
        {
            _context = context;
        }

        public List<Usuari> GetUsuaris()
        {
            return _context.Usuaris.OrderBy(u => u.correu).ThenBy(u => u.nom).ToList();
        }
    }
}
