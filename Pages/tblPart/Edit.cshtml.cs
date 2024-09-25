using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblPart
{
    public class EditModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public EditModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblPart TblPart { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblParts == null)
            {
                return NotFound();
            }

            var tblpart =  await _context.TblParts.FirstOrDefaultAsync(m => m.PartId == id);
            if (tblpart == null)
            {
                return NotFound();
            }
            TblPart = tblpart;
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

            _context.Attach(TblPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPartExists(TblPart.PartId))
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

        private bool TblPartExists(int id)
        {
          return (_context.TblParts?.Any(e => e.PartId == id)).GetValueOrDefault();
        }
    }
}
