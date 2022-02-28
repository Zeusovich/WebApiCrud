using Microsoft.EntityFrameworkCore;
using TestTaskWebApi.Context;
using TestTaskWebApi.Models;

namespace TestTaskWebApi.Services
{
    public class ContactService
    {
        private readonly ContactContext _context;
        public ContactService(ContactContext context)
        {
            this._context = context;
        }

        public async Task<List<Contact>> GetAll() =>        
            await _context.Contacts.ToListAsync();

        public async Task<Contact> GetById(int id) =>
            await _context.Contacts.SingleOrDefaultAsync(x => x.Id == id);

        public async Task Add(Contact contact)
        {
            if (contact != null)
            {
                await _context.Contacts.AddAsync(contact);
                _context.SaveChanges();
            }
        }

        public async Task<Contact> Update(Contact contact1)
        {
            var contact = await _context.Contacts.Where(o=>o.Id == contact1.Id).SingleOrDefaultAsync();
            if (contact == null)
            {
                throw new ArgumentNullException($"Contact with id {contact1.Id} not found");
            };
            contact.Name = contact1.Name;
            contact.MobilePhone = contact1.MobilePhone;
            contact.JobTitle = contact1.JobTitle;
            contact.BirthDate = contact1.BirthDate;
            
            _context.SaveChanges();
            return contact;
        }

        public async Task Delete(int id)
        {
            var contact = await _context.Contacts.Where(o => o.Id == id).SingleOrDefaultAsync();
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            else
                throw new ArgumentNullException($"Contact with id {id} not found");
        }
    }
}
