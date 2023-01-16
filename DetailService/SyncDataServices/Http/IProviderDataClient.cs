using System.Threading.Tasks;
using DetailService.Dtos;

namespace DetailService.SyncDataServices.Http
{
    public interface IProviderDataClient
    {
        Task SendDetailToCommand(DetailReadDto det);
    }
}