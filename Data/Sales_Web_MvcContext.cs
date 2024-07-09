using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales_Web_Mvc.Models;

namespace Sales_Web_Mvc.Data
{
    public class Sales_Web_MvcContext : DbContext
    {
        public Sales_Web_MvcContext (DbContextOptions<Sales_Web_MvcContext> options)
            : base(options)
        {
        }

        public DbSet<Sales_Web_Mvc.Models.Department> Department { get; set; } = default!;
    }
}
