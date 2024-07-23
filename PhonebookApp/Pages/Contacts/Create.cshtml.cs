using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhonebookApp.Models;
using PhonebookApp.Services;

namespace PhonebookApp.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly ContactService _contactService;

        [BindProperty]
        public Contact Contact { get; set; }

        public CreateModel(ContactService contactService)
        {
            _contactService = contactService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contactService.AddContact(Contact);
            return RedirectToPage("./Index");
        }
    }
}
