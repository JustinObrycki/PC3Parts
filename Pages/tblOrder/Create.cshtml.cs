using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblOrder
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
        ViewData["CustomerId"] = new SelectList(_context.TblCustomers, "CustomerId", "CustomerId");
        ViewData["EmployeeId"] = new SelectList(_context.TblEmployees, "EmployeeId", "EmployeeId");
        ViewData["PartId"] = new SelectList(_context.TblParts, "PartId", "PartId");
            return Page();
        }

        [BindProperty]
        public TblOrder TblOrder { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblOrders == null || TblOrder == null)
            {
                return Page();
            }

            _context.TblOrders.Add(TblOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
