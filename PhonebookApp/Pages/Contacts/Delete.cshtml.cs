using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhonebookApp.Models;
using PhonebookApp.Services;

namespace PhonebookApp.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly ContactService _contactService;

        [BindProperty]
        public Contact Contact { get; set; }

        public DeleteModel(ContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult OnGet(int id)
        {
            Contact = _contactService.GetContactById(id);

            if (Contact == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            _contactService.DeleteContact(Contact.Id);
            return RedirectToPage("./Index");
        }
    }
}
