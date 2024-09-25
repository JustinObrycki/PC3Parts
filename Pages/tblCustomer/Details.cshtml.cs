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
    public class DetailsModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public DetailsModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

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
    }
}
