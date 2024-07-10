using Sales_Web_Mvc.Data;
using Sales_Web_Mvc.Models;

namespace Sales_Web_Mvc.Services
{
    public class SellerService
    {
        private readonly Sales_Web_MvcContext _context;

        public SellerService(Sales_Web_MvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
