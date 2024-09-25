using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectObryckiJustin;

namespace ProjectObryckiJustin.Pages.DataVisualization.MyProcedures
{
    public class CustomerTotalModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public CustomerTotalModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        public IList<spCustomerTotal> spCustomerTotal { get; set; }

        public async Task OnGetAsync()
        {

            try
            {
                spCustomerTotal = await _context.spCustomerTotal.FromSqlRaw("exec spCustomerTotal").ToListAsync();
            }
            catch (Exception)
            {

            }
        }
        public async Task OnPostAsync()
        {
            spCustomerTotal = await _context.spCustomerTotal.FromSqlRaw("exec spCustomerTotal").ToListAsync();
        }
    }
}
