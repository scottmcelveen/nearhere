using System.Threading.Tasks;
using Plugin.Geolocator;

namespace Services.Location
{
    public class LocationService : ILocationService
    {
        public async Task<bool> IsLocationAvailableAsync()
        {
            return await CrossGeolocator.Current.GetIsGeolocationAvailableAsync();
        }
    }
}
