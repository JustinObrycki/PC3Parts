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
    public class EmployeeTotalSalesModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public EmployeeTotalSalesModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        public IList<spEmployeeTotalSales> spEmployeeTotalSales { get; set; }

        public async Task OnGetAsync()
        {

            try
            {
                spEmployeeTotalSales = await _context.spEmployeeTotalSales.FromSqlRaw("exec spEmployeeTotalSales").ToListAsync();
            }
            catch (Exception)
            {

            }
        }
        public async Task OnPostAsync()
        {
            spEmployeeTotalSales = await _context.spEmployeeTotalSales.FromSqlRaw("exec spEmployeeTotalSales").ToListAsync();
        }
    }
}
