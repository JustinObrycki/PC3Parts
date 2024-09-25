using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblOrder
{
    public class EditModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public EditModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TblOrder TblOrder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblOrders == null)
            {
                return NotFound();
            }

            var tblorder =  await _context.TblOrders.FirstOrDefaultAsync(m => m.OrderNo == id);
            if (tblorder == null)
            {
                return NotFound();
            }
            TblOrder = tblorder;
           ViewData["CustomerId"] = new SelectList(_context.TblCustomers, "CustomerId", "CustomerId");
           ViewData["EmployeeId"] = new SelectList(_context.TblEmployees, "EmployeeId", "EmployeeId");
           ViewData["PartId"] = new SelectList(_context.TblParts, "PartId", "PartId");
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

            _context.Attach(TblOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblOrderExists(TblOrder.OrderNo))
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

        private bool TblOrderExists(int id)
        {
          return (_context.TblOrders?.Any(e => e.OrderNo == id)).GetValueOrDefault();
        }
    }
}
