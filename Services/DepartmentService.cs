using Microsoft.EntityFrameworkCore;
using Sales_Web_Mvc.Data;
using Sales_Web_Mvc.Models;

namespace Sales_Web_Mvc.Services
{
    public class DepartmentService(Sales_Web_MvcContext context)
    {
        private Sales_Web_MvcContext _context = context;

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}
