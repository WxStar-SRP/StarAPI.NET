using System.Net.Http.Json;
using WxStarManager.Models;

namespace WxStarManager;

public partial class Api
{
    public async Task<bool> RegisterService(SystemServiceIn inModel)
    {
        try
        {
            var response = await _client.PostAsJsonAsync($"{Uri}/services/register", inModel);
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (HttpRequestException e)
        {
            return false;
        }
    }

    public async Task ReportUptime(SystemServiceReport inModel, string serviceUuid)
    {
        try
        {
            var response = await _client.PutAsJsonAsync($"{Uri}/services/report_up?service_uuid={serviceUuid}",
                                                        inModel);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Failed to update uptime.");
            Console.WriteLine(e.Message);
        }
    }

    public async Task<List<string>> GetMoonLocations(WxStarModel starModel)
    {
        string starModelString = StarModelToString(starModel);

        if (starModelString == String.Empty)
        {
            throw new Exception("No star model was specified.");
        }

        var response = await _client.GetAsync($"{Uri}/services/moon/wxstar_locids?star_model={starModelString}");

        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadFromJsonAsync<MoonLocationResponse>();

        return content.Locations;
    }
}