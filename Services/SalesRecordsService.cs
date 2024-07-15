using Microsoft.EntityFrameworkCore;
using Sales_Web_Mvc.Data;
using Sales_Web_Mvc.Models;

namespace Sales_Web_Mvc.Services
{
    public class SalesRecordsService(Sales_Web_MvcContext context)
    {
        private readonly Sales_Web_MvcContext _context = context;

       public async Task<List<SalesRecord>> FindByDateAsync (DateTime? minDate, DateTime? maxDate)
        {
            IQueryable<SalesRecord> result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue)result = result.Where(x => x.Date >= minDate.Value);
            if (maxDate.HasValue)result = result.Where(x => x.Date <= maxDate.Value);
            
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            IQueryable<SalesRecord> result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue) result = result.Where(x => x.Date >= minDate.Value);
            if (maxDate.HasValue) result = result.Where(x => x.Date <= maxDate.Value);

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
