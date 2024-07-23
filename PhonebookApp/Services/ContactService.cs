using PhonebookApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhonebookApp.Services
{
    public class ContactService
    {
        private readonly List<Contact> _contacts;

        public ContactService()
        {
            _contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "John Doe", PhoneNumber = "123456789" },
                new Contact { Id = 2, Name = "Jane Smith", PhoneNumber = "987654321" }
            };
        }

        public List<Contact> GetContacts()
        {
            return _contacts;
        }

        public Contact GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            contact.Id = _contacts.Max(c => c.Id) + 1;
            _contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.Name = contact.Name;
                existingContact.PhoneNumber = contact.PhoneNumber;
            }
        }
        public void DeleteContact(int id)
        {
            var contact = GetContactById(id);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }
    }
}