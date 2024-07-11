﻿using Sales_Web_Mvc.Data;
using Sales_Web_Mvc.Models;

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
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

    }
}
