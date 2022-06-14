using System.Collections.Generic;
using System.Linq;
using TesteEngegraph.Database;
using TesteEngegraph.Models;

namespace TesteEngegraph.Services
{
    public class TypeService : ITypeService
    {
        private readonly DataContext _context;

        public TypeService(DataContext data)
        {
            _context = data;
        }

        public Types Insert(Types tipo)
        {
            _context.Types.Add(tipo);
            _context.SaveChanges();

            return tipo;
        }

        public List<Types> GetAll()
        {
            return _context.Types.OrderBy(x => x.Name).ToList();
        }
    }
}
