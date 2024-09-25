using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblEmployee
{
    public class EditModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public EditModel(ProjectObryckiJustin.Jobrycki1Context context)
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

            var tblemployee =  await _context.TblEmployees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (tblemployee == null)
            {
                return NotFound();
            }
            TblEmployee = tblemployee;
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

            _context.Attach(TblEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeExists(TblEmployee.EmployeeId))
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

        private bool TblEmployeeExists(int id)
        {
          return (_context.TblEmployees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
