using System.Collections.Generic;
using TesteEngegraph.Models;

namespace TesteEngegraph.Services
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact Insert(Contact contato);
    }
}
