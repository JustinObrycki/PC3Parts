using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblEmployee
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public DeleteModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public TblEmployee TblEmployee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblEmployees == null)
            {
                return NotFound();
            }

            var tblemployee = await _context.TblEmployees.FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (tblemployee == null)
            {
                return NotFound();
            }
            else 
            {
                TblEmployee = tblemployee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblEmployees == null)
            {
                return NotFound();
            }
            var tblemployee = await _context.TblEmployees.FindAsync(id);

            if (tblemployee != null)
            {
                TblEmployee = tblemployee;
                _context.TblEmployees.Remove(TblEmployee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
