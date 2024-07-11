using Microsoft.EntityFrameworkCore;
using Sales_Web_Mvc.Data;
using Sales_Web_Mvc.Models;
using Sales_Web_Mvc.Services.Exceptions;

namespace Sales_Web_Mvc.Services
{
    public class SellerService(Sales_Web_MvcContext context)
    {
        private readonly Sales_Web_MvcContext _context = context;

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller newSeller) 
        {
            _context.Add(newSeller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new DirectoryNotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
