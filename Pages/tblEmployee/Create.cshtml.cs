using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblEmployee
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
        public TblEmployee TblEmployee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblEmployees == null || TblEmployee == null)
            {
                return Page();
            }

            _context.TblEmployees.Add(TblEmployee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
