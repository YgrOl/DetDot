using System;
using System.Collections.Generic;
using System.Linq;
using DetailService.Models;

namespace DetailService.Data
{
    public class DetailRepo : IDetailRepo
    {
        private readonly AppDbContext _context;

        public DetailRepo(AppDbContext context)
        {
            _context = context;
        }


        public void CreateDetail(Detail det)
        {
            if (det == null)
            {
                throw  new ArgumentNullException(nameof(det));
            }

            _context.Details.Add(det);
        }

        public IEnumerable<Detail> GetAllDetails()
        {
            return _context.Details.ToList();
        }

        public Detail GetDetailById(int id)
        {
            return _context.Details.FirstOrDefault(p =>p.Id ==id);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >=0);
        }
    }

}