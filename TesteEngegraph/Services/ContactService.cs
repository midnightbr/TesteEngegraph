using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEngegraph.Database;
using TesteEngegraph.Models;

namespace TesteEngegraph.Services
{
    public class ContactService : IContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext data)
        {
            _context = data;
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact Insert(Contact contato)
        {
            using (var db = _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Logs ON");
            }
            _context.Contacts.Add(contato);
            
            _context.SaveChanges();

            return contato;
        }
    }
}
