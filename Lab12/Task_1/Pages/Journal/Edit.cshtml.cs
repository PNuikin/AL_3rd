using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task_1.Context;

namespace Task_1.Pages.Journal
{
    public class EditModel : PageModel
    {
        private MyDbContext _context;

        public EditModel(MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entities.Journal Journal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.journals == null)
            {
                return NotFound();
            }

            var journal =  await _context.journals.FirstOrDefaultAsync(m => m.journalId == id);
            if (journal == null)
            {
                return NotFound();
            }
            Journal = journal;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Journal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(Journal.journalId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OfficeExists(int id)
        {
          return (_context.journals?.Any(e => e.journalId == id)).GetValueOrDefault();
        }
    }
}
