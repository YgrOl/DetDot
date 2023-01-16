using System;
using System.Collections.Generic;
using System.Linq;
using ProvidersService.Models;

namespace ProvidersService.Data
{
    public class ProviderRepo : IProviderRepo
    {
        private readonly AppDbContext _context;

        public ProviderRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProvider(int detailId, Provider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            provider.DetailId = detailId;
            _context.Providers.Add(provider);
        }

        public void CreateDetail(Detail det)
        {
            if(det == null)
            {
                throw new ArgumentNullException(nameof(det));
            }
            _context.Details.Add(det);
        }

        public bool ExternalDetailExists(int externalDetailId)
        {
            return _context.Details.Any(p => p.ExternalID == externalDetailId);
        }

        public IEnumerable<Detail> GetAllDetails()
        {
            return _context.Details.ToList();
        }

        public Provider GetProvider(int detailId, int providerId)
        {
            return _context.Providers
                .Where(c => c.DetailId == detailId && c.Id == providerId).FirstOrDefault();
        }

        public IEnumerable<Provider> GetProvidersForDetail(int detailId)
        {
            return _context.Providers
                .Where(c => c.DetailId == detailId)
                .OrderBy(c => c.Detail.Name);
        }

        public bool DetailExits(int detailId)
        {
            return _context.Details.Any(p => p.Id == detailId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}