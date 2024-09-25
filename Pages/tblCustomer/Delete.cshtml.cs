using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblCustomer
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public DeleteModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        [BindProperty]
      public TblCustomer TblCustomer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblCustomers == null)
            {
                return NotFound();
            }

            var tblcustomer = await _context.TblCustomers.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (tblcustomer == null)
            {
                return NotFound();
            }
            else 
            {
                TblCustomer = tblcustomer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblCustomers == null)
            {
                return NotFound();
            }
            var tblcustomer = await _context.TblCustomers.FindAsync(id);

            if (tblcustomer != null)
            {
                TblCustomer = tblcustomer;
                _context.TblCustomers.Remove(TblCustomer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
