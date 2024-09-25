using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace ProjectObryckiJustin.Pages.DataVisualization.MyViews
{
    public class EmployeeSalesModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;


        public EmployeeSalesModel(Jobrycki1Context context)
        {
            _context = context;
        }

        public IList<VwEmployeeSale> VwEmployeeSale { get; set; }
        public async Task OnGetAsync()
        {
            VwEmployeeSale = await _context.VwEmployeeSales.ToListAsync();
        }
    }
}
