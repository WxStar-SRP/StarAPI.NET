using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WxStarManager.Models;

namespace WxStarManager;

public partial class Api
{
    public async Task<StarInfo> RegisterStar(WxStarIn inModel)
    {
        var serializedModel = JsonConvert.SerializeObject(inModel);
        var content = new StringContent(serializedModel, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"{Uri}/wxstar/register", content);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<StarInfo>();

        return responseContent;
    }

    public async Task<StarInfo> GetStarInfo(string starUuid)
    {
        var response = await _client.GetAsync($"{Uri}/wxstar/{starUuid}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<StarInfo>();

        return responseContent;
    }

    public async Task<bool> UnregisterStar(string starUuid)
    {
        try
        {
            var response = await _client.DeleteAsync($"{Uri}/wxstar/unregister?star_uuid={starUuid}");
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (HttpRequestException e)
        {
            return false;
        }
    }

    public async Task<List<StarCueSetting>> GetStarCueSettings(WxStarModel starModel)
    {
        var starModelString = StarModelToString(starModel);

        var response = await _client.GetAsync($"{Uri}/services/cuer/star_cue_settings?star_model={starModelString}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<StarCueSettings>();

        return content.CueSettings;
    }

    public async Task UpdateUnitLocations(string starUuid, List<string> locations, List<string>? zones = null)
    {
        var locationUpdate = new WxStarLocationUpdate() { Locations = locations, Zones = zones };
        var content = new StringContent(JsonConvert.SerializeObject(locationUpdate), Encoding.UTF8, "application/json");

        var response = await _client.PutAsync($"{Uri}/wxstar/{starUuid}/set_locations", content);
        response.EnsureSuccessStatusCode();
    }
}