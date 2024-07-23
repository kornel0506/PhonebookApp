using Microsoft.AspNetCore.Mvc.RazorPages;
using PhonebookApp.Models;
using PhonebookApp.Services;
using System.Collections.Generic;

namespace PhonebookApp.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly ContactService _contactService;

        public IndexModel(ContactService contactService)
        {
            _contactService = contactService;
        }

        public IList<Contact> Contacts { get; set; }

        public void OnGet()
        {
            Contacts = _contactService.GetContacts();
        }
    }
}
