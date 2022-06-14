using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEngegraph.Database;
using TesteEngegraph.Models;
using TesteEngegraph.Services;

namespace TesteEngegraph.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _context;
        private readonly IContactService _contatoService;
        private readonly ITypeService _tipoService;

        public ContactController(DataContext context, IContactService contatoService, ITypeService tipoService)
        {
            _context = context;
            _contatoService = contatoService;
            _tipoService = tipoService;
        }

        // GET: Contacts
        public async Task<IActionResult> Index(string search, string column)
        {
            Common common = new Common();
            common.ListContacts = _contatoService.GetAll();

            if (column == "Contact")
            {
                var contacts = from contact in _context.Contacts select contact;
                if (!string.IsNullOrEmpty(search))
                {
                    contacts = contacts.Where(s => s.Nome.Contains(search));
                    common.ListContacts = await contacts.ToListAsync();
                }
            }
            if (column == "Type")
            {
                var contacts = from contact in _context.Contacts select contact;
                if (!string.IsNullOrEmpty(search))
                {
                    contacts = contacts.Where(s => s.Types.Name.Contains(search));
                    common.ListContacts = await contacts.ToListAsync();
                }
            }

            common.ListTypes = _tipoService.GetAll();
            var dataContext = _context.Contacts.Include(c => c.Types);

            return View(common);
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Types)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            ViewData["TypesId"] = new SelectList(_context.Types, "Id", "Name");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Cpf,Sexo,TypesId,Ativo")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypesId"] = new SelectList(_context.Types, "Id", "Name", contact.TypesId);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["TypesId"] = new SelectList(_context.Types, "Id", "Name", contact.TypesId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Cpf,Sexo,TypesId,Ativo")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypesId"] = new SelectList(_context.Types, "Id", "Name", contact.TypesId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.Types)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}