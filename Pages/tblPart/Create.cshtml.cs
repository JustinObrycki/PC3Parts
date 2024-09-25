using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblPart
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
        public TblPart TblPart { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblParts == null || TblPart == null)
            {
                return Page();
            }

            _context.TblParts.Add(TblPart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
