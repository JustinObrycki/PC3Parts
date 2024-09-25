using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjectObryckiJustin.Pages.DataVisualization.MyProcedures
{
    public class SaleByDateModel : PageModel
    {
        private readonly ProjectObryckiJustin.Jobrycki1Context _context;

        public SaleByDateModel(ProjectObryckiJustin.Jobrycki1Context context)
        {
            _context = context;
        }

        public IList<spSaleByDate> spSaleByDate { get; set; }

        public async Task OnGetAsync()
        {

            try
            {
                var StartTimeSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@StartTime", "");
                var EndTimeSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@EndTime", "");
                spSaleByDate = await _context.spSaleByDate.FromSqlRaw("exec spSaleByDate @StartTime={0}, @EndTime={1}", StartTimeSQLParam, EndTimeSQLParam).ToListAsync();
            }
            catch (Exception)
            {
                

            }
        }
        public async Task OnPostAsync()
        {
            try
            {

                string StartTime = HttpContext.Request.Form["StartTime"];
                string EndTime = HttpContext.Request.Form["EndTime"];

                var StartTimeSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@StartTime", StartTime);
                var EndTimeSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@EndTime", EndTime);
                spSaleByDate = await _context.spSaleByDate.FromSqlRaw("exec spSaleByDate @StartTime={0}, @EndTime={1}", StartTimeSQLParam, EndTimeSQLParam).ToListAsync();


            }

            catch (Exception)
            {
           
            }
        }
    }
}
