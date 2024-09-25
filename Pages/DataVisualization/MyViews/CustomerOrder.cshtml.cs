using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace ProjectObryckiJustin.Pages.DataVisualization.MyViews
{
    public class CustomerOrderModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CustomerOrderModel(Jobrycki1Context context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _context = context;
        }

        public IList<VwCustomerOrder> VwCustomerOrder { get; set; }
        public async Task OnGetAsync()
        {
            VwCustomerOrder = await _context.VwCustomerOrders.ToListAsync();
        }
    }
}
