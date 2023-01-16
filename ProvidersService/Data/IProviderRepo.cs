using System.Collections.Generic;
using ProvidersService.Models;

namespace ProvidersService.Data
{
    public interface IProviderRepo
    {
        bool SaveChanges();

        // Details
        IEnumerable<Detail> GetAllDetails();
        void CreateDetail(Detail det);
        bool DetailExits(int detailId);
        bool ExternalDetailExists(int externalDetailId);

        // Providers
        IEnumerable<Provider> GetProvidersForDetail(int detailId);
        Provider GetProvider(int detailId, int providerId);
        void CreateProvider(int detailId, Provider provider);
    }
}