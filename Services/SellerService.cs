using Microsoft.EntityFrameworkCore;
using Sales_Web_Mvc.Data;
using Sales_Web_Mvc.Models;
using Sales_Web_Mvc.Services.Exceptions;

namespace Sales_Web_Mvc.Services
{
    public class SellerService(Sales_Web_MvcContext context)
    {
        private readonly Sales_Web_MvcContext _context = context;

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }
        public async Task InsertAsync(Seller newSeller) 
        {
            _context.Add(newSeller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hashAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hashAny)
            {
                throw new DirectoryNotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
