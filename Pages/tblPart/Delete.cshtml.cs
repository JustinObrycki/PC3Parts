﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblPart
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public DeleteModel(ProjectObryckiJustin.Jobrycki1Context context)
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

            var tblpart = await _context.TblParts.FirstOrDefaultAsync(m => m.PartId == id);

            if (tblpart == null)
            {
                return NotFound();
            }
            else 
            {
                TblPart = tblpart;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblParts == null)
            {
                return NotFound();
            }
            var tblpart = await _context.TblParts.FindAsync(id);

            if (tblpart != null)
            {
                TblPart = tblpart;
                _context.TblParts.Remove(TblPart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
