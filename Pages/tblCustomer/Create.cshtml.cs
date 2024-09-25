using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblCustomer
{
    public class CreateModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public CreateModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblCustomer TblCustomer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblCustomers == null || TblCustomer == null)
            {
                return Page();
            }

            _context.TblCustomers.Add(TblCustomer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
