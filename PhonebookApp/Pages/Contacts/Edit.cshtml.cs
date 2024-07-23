using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhonebookApp.Models;
using PhonebookApp.Services;

namespace PhonebookApp.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly ContactService _contactService;

        [BindProperty]
        public Contact Contact { get; set; }

        public EditModel(ContactService contactService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contactService.UpdateContact(Contact);
            return RedirectToPage("./Index");
        }
    }
}
