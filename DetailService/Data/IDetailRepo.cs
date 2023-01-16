using System.Collections.Generic;
using DetailService.Models;

namespace DetailService.Data
{
    public interface IDetailRepo
    {
        bool SaveChanges();

        IEnumerable<Detail> GetAllDetails();
        Detail GetDetailById(int id);
        void CreateDetail(Detail det);
    }
}