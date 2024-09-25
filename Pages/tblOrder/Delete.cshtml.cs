using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblOrder
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public DeleteModel(ProjectObryckiJustin.Jobrycki1Context context)
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

            var tblorder = await _context.TblOrders.FirstOrDefaultAsync(m => m.OrderNo == id);

            if (tblorder == null)
            {
                return NotFound();
            }
            else 
            {
                TblOrder = tblorder;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblOrders == null)
            {
                return NotFound();
            }
            var tblorder = await _context.TblOrders.FindAsync(id);

            if (tblorder != null)
            {
                TblOrder = tblorder;
                _context.TblOrders.Remove(TblOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
