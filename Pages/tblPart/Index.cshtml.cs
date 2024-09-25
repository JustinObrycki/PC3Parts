using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.tblPart
{
    public class IndexModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public IndexModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        public IList<TblPart> TblPart { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TblParts != null)
            {
                TblPart = await _context.TblParts.ToListAsync();
            }
        }
    }
}
