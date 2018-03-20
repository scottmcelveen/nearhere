using System.Threading.Tasks;

namespace Services.Location
{
    public interface ILocationService
    {
        Task<bool> IsLocationAvailableAsync();
    }
}
