﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblCustomer
{
    public class EditModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public EditModel(ProjectObryckiJustin.Jobrycki1Context context)
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

            var tblcustomer =  await _context.TblCustomers.FirstOrDefaultAsync(m => m.CustomerId == id);
            if (tblcustomer == null)
            {
                return NotFound();
            }
            TblCustomer = tblcustomer;
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

            _context.Attach(TblCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerExists(TblCustomer.CustomerId))
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

        private bool TblCustomerExists(int id)
        {
          return (_context.TblCustomers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
