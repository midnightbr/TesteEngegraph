using System.Collections.Generic;
using TesteEngegraph.Services;

namespace TesteEngegraph.Models
{
    public class Common
    {
        private readonly IContactService _contactService;
        private readonly ITypeService _typeService;

        public Contact Contact { get; set; }
        public Types Types { get; set; }
        public List<Contact> ListContacts { get; set; } = new List<Contact>();
        public List<Types> ListTypes { get; set; } = new List<Types>();

        public void List()
        {
            List<Contact> ListContacts = _contactService.GetAll();
            List<Types> ListTypes = _typeService.GetAll();
        }

    }
}
